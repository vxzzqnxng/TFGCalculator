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
    private bool _energyOpen, _machOpen, _rawOpen;
    private int _ampTierLevel = 2;

    protected override async Task OnInitializedAsync()
    {
        Loc.OnLanguageChanged += OnLangChanged;

        var requests = ModpackItems.PendingRequests;
        _modpackId = ModpackItems.PendingModpackId ?? "";

        Dictionary<string, string>? savedChoices = null;
        Dictionary<string, int>? savedTiers = null;
        Dictionary<string, int>? savedCoils = null;

        if (requests != null && requests.Any() && !string.IsNullOrEmpty(_modpackId))
        {
            savedChoices = await Storage.LoadAsync<Dictionary<string, string>>($"recipeChoices_{_modpackId}");
            savedTiers = await Storage.LoadAsync<Dictionary<string, int>>($"tierChoices_{_modpackId}");
            savedCoils = await Storage.LoadAsync<Dictionary<string, int>>($"coilChoices_{_modpackId}");
            _result = CalcSvc.Calculate(_modpackId, requests, savedChoices, savedTiers, savedCoils);
            await SaveState(requests);
            return;
        }

        var saved = await Storage.LoadAsync<SavedCalculationState>("lastCalc");
        if (saved != null && !string.IsNullOrEmpty(saved.ModpackId) && saved.Requests.Any())
        {
            _modpackId = saved.ModpackId;
            savedChoices = saved.RecipeChoices ?? await Storage.LoadAsync<Dictionary<string, string>>($"recipeChoices_{_modpackId}");
            savedTiers = saved.TierChoices ?? await Storage.LoadAsync<Dictionary<string, int>>($"tierChoices_{_modpackId}");
            savedCoils = saved.CoilChoices ?? await Storage.LoadAsync<Dictionary<string, int>>($"coilChoices_{_modpackId}");

            var restored = new List<ProductionRequest>();
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
                restored.Add(pr);
            }
            if (restored.Any())
                _result = CalcSvc.Calculate(_modpackId, restored, savedChoices, savedTiers, savedCoils);
        }
    }

    private async Task SaveState(List<ProductionRequest> requests)
    {
        var state = new SavedCalculationState
        {
            ModpackId = _modpackId,
            Requests = requests.Select(r => new SavedRequestItem
            {
                ItemId = r.Item.Id,
                AmountPerSecond = r.AmountPerSecond,
                RateType = (int)r.RateType,
                MachineCountValue = r.MachineCountValue
            }).ToList(),
            RecipeChoices = _result != null ? CalculationService.CollectRecipeChoices(_result.RootNodes) : null,
            TierChoices = _result != null ? CalculationService.CollectTierChoices(_result.RootNodes) : null,
            CoilChoices = _result != null ? CalculationService.CollectCoilChoices(_result.RootNodes) : null
        };
        await Storage.SaveAsync("lastCalc", state);
    }

    private double CalcAmps(double totalEUt)
    {
        double perAmp = 32 * Math.Pow(4, _ampTierLevel - 2);
        return perAmp > 0 ? totalEUt / perAmp : 0;
    }

    private async void HandleChanged()
    {
        if (_result == null) return;

        // Full DAG recalculation
        CalcSvc.RecalculateDAG(_result.RootNodes);
        CalcSvc.RefreshAllNames(_modpackId, _result.RootNodes);
        var (m, r2, e) = CalcSvc.RebuildSummaries(_result.RootNodes);
        _result.Machines = m;
        _result.RawResources = r2;
        _result.EnergySummaries = e;
        StateHasChanged();

        var choices = CalculationService.CollectRecipeChoices(_result.RootNodes);
        await Storage.SaveAsync($"recipeChoices_{_modpackId}", choices);
        var tiers = CalculationService.CollectTierChoices(_result.RootNodes);
        await Storage.SaveAsync($"tierChoices_{_modpackId}", tiers);
        var coils = CalculationService.CollectCoilChoices(_result.RootNodes);
        await Storage.SaveAsync($"coilChoices_{_modpackId}", coils);

        var saved = await Storage.LoadAsync<SavedCalculationState>("lastCalc");
        if (saved != null)
        {
            saved.RecipeChoices = choices;
            saved.TierChoices = tiers;
            saved.CoilChoices = coils;
            await Storage.SaveAsync("lastCalc", saved);
        }
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
}