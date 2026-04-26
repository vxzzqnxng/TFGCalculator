using Microsoft.AspNetCore.Components;
using TFGCalculator.Models;
using TFGCalculator.Services;

namespace TFGCalculator.Pages;

public partial class CalculationResult : ComponentBase, IDisposable
{
    [Inject] private CalculationService CalcSvc { get; set; } = default!;
    [Inject] private NavigationManager Nav { get; set; } = default!;
    [Inject] private LocalizationService Loc { get; set; } = default!;
    [Inject] private StorageService Storage { get; set; } = default!;
    [Inject] private ItemService ItemSvc { get; set; } = default!;
    [Inject] private RecipeService RecipeSvc { get; set; } = default!;

    private TFGCalculator.Services.CalculationResult? _result;
    private string _modpackId = "";
    private string _treeId = "";
    private List<ProductionRequest> _requests = new();
    private bool _energyOpen, _machOpen, _rawOpen;
    private int _ampTierLevel = 2;


    protected override async Task OnInitializedAsync()
    {
        Loc.OnLanguageChanged += OnLangChanged;

        var requests = ModpackItems.PendingRequests;
        _modpackId = ModpackItems.PendingModpackId ?? "";
        _treeId = ModpackItems.PendingTreeId ?? "";

        if (!string.IsNullOrEmpty(_modpackId))
        {
            await ItemSvc.EnsureLoadedAsync(_modpackId);
            await RecipeSvc.EnsureLoadedAsync(_modpackId);
        }

        Dictionary<string, string>? savedChoices = null;
        Dictionary<string, int>? savedTiers = null;
        Dictionary<string, int>? savedCoils = null;

        if (requests != null && requests.Any() && !string.IsNullOrEmpty(_modpackId))
        {
            _requests = requests;
            savedChoices = await Storage.LoadAsync<Dictionary<string, string>>(ChoiceKey("recipe"));
            savedTiers = await Storage.LoadAsync<Dictionary<string, int>>(ChoiceKey("tier"));
            savedCoils = await Storage.LoadAsync<Dictionary<string, int>>(ChoiceKey("coil"));
            _result = CalcSvc.Calculate(_modpackId, _requests, savedChoices, savedTiers, savedCoils);
            await SaveState();
            return;
        }

        // Restore on reload
        var saved = await Storage.LoadAsync<SavedCalculationState>("lastCalc");
        if (saved != null && !string.IsNullOrEmpty(saved.ModpackId) && saved.Requests.Any())
        {
            _modpackId = saved.ModpackId;
            _treeId = saved.TreeId ?? "";
            savedChoices = saved.RecipeChoices ?? await Storage.LoadAsync<Dictionary<string, string>>(ChoiceKey("recipe"));
            savedTiers = saved.TierChoices ?? await Storage.LoadAsync<Dictionary<string, int>>(ChoiceKey("tier"));
            savedCoils = saved.CoilChoices ?? await Storage.LoadAsync<Dictionary<string, int>>(ChoiceKey("coil"));

            _requests = new List<ProductionRequest>();
            foreach (var sr in saved.Requests)
            {
                var item = ItemSvc.GetById(saved.ModpackId, sr.ItemId);
                if (item == null) continue;
                var pr = new ProductionRequest
                {
                    Item = item,
                    AmountPerSecond = sr.AmountPerSecond,
                    RateType = (RateType)sr.RateType,
                    MachineCountValue = sr.MachineCountValue
                };
                if (pr.RateType == RateType.MachineCount)
                {
                    var recipe = RecipeSvc.FindRecipeForOutput(_modpackId, sr.ItemId);
                    if (recipe != null)
                    {
                        double d = recipe.DurationTicks / 20.0;
                        var o = recipe.Outputs.First(x => x.ItemId == sr.ItemId);
                        pr.AmountPerSecond = (d > 0 ? 1.0 / d : 0) * o.Amount * sr.MachineCountValue;
                    }
                }
                _requests.Add(pr);
            }
            if (_requests.Any())
                _result = CalcSvc.Calculate(_modpackId, _requests, savedChoices, savedTiers, savedCoils);
        }
    }

    private string ChoiceKey(string kind) =>
        string.IsNullOrEmpty(_treeId)
            ? $"{kind}Choices_{_modpackId}"
            : $"{kind}Choices_{_modpackId}_{_treeId}";
    private async Task SaveState()
    {
        if (_result == null) return;
        var choices = CalculationService.CollectRecipeChoices(_result.RootNodes);
        var tiers = CalculationService.CollectTierChoices(_result.RootNodes);
        var coils = CalculationService.CollectCoilChoices(_result.RootNodes);

        await Storage.SaveAsync(ChoiceKey("recipe"), choices);
        await Storage.SaveAsync(ChoiceKey("tier"), tiers);
        await Storage.SaveAsync(ChoiceKey("coil"), coils);

        await Storage.SaveAsync("lastCalc", new SavedCalculationState
        {
            ModpackId = _modpackId,
            Requests = _requests.Select(r => new SavedRequestItem
            {
                ItemId = r.Item.Id,
                AmountPerSecond = r.AmountPerSecond,
                RateType = (int)r.RateType,
                MachineCountValue = r.MachineCountValue
            }).ToList(),
            RecipeChoices = choices,
            TierChoices = tiers,
            CoilChoices = coils
        });
    }

    private double CalcAmps(double totalEUt)
    {
        double perAmp = 32 * Math.Pow(4, _ampTierLevel - 2);
        return perAmp > 0 ? totalEUt / perAmp : 0;
    }

    /// <summary>Full rebuild on ANY change (recipe/tier/coil/storage)</summary>
    private async void HandleChanged()
    {
        if (_result == null || !_requests.Any()) return;

        // Collect current choices, merge with saved
        var currentChoices = CalculationService.CollectRecipeChoices(_result.RootNodes);
        var savedChoices = await Storage.LoadAsync<Dictionary<string, string>>(ChoiceKey("recipe")) ?? new();
        foreach (var kv in currentChoices) savedChoices[kv.Key] = kv.Value;

        var currentTiers = CalculationService.CollectTierChoices(_result.RootNodes);
        var savedTiers = await Storage.LoadAsync<Dictionary<string, int>>(ChoiceKey("tier")) ?? new();
        foreach (var kv in currentTiers) savedTiers[kv.Key] = kv.Value;

        var currentCoils = CalculationService.CollectCoilChoices(_result.RootNodes);
        var savedCoils = await Storage.LoadAsync<Dictionary<string, int>>(ChoiceKey("coil")) ?? new();
        foreach (var kv in currentCoils) savedCoils[kv.Key] = kv.Value;

        // Full rebuild with merged choices
        _result = CalcSvc.Calculate(_modpackId, _requests, savedChoices, savedTiers, savedCoils);
        CalcSvc.RefreshAllNames(_modpackId, _result.RootNodes);
        StateHasChanged();
        await SaveState();
    }

    private void OnLangChanged()
    {
        if (_result != null)
        {
            CalcSvc.RefreshAllNames(_modpackId, _result.RootNodes);
            var (m, r, e) = CalcSvc.RebuildSummaries(_result.RootNodes);
            _result.Machines = m; _result.RawResources = r; _result.EnergySummaries = e;
        }
        StateHasChanged();
    }

    public void Dispose() => Loc.OnLanguageChanged -= OnLangChanged;

    private async Task HandleAddAlternative(string itemId)
    {
        if (string.IsNullOrEmpty(_modpackId)) return;
        var item = ItemSvc.GetById(_modpackId, itemId);
        if (item == null) return;

        _requests.Add(new ProductionRequest
        {
            Item = item,
            AmountPerSecond = 0,          // пользователь сам настроит спрос/только просмотр
            RateType = RateType.ViewOnly
        });

        // Полный rebuild — вариантная логика (VariantSuffix) уже в CalculationService
        var savedChoices = await Storage.LoadAsync<Dictionary<string, string>>(ChoiceKey("recipe")) ?? new();
        var savedTiers = await Storage.LoadAsync<Dictionary<string, int>>(ChoiceKey("tier")) ?? new();
        var savedCoils = await Storage.LoadAsync<Dictionary<string, int>>(ChoiceKey("coil")) ?? new();

        _result = CalcSvc.Calculate(_modpackId, _requests, savedChoices, savedTiers, savedCoils);
        CalcSvc.RefreshAllNames(_modpackId, _result.RootNodes);
        StateHasChanged();
        await SaveState();
    }
}