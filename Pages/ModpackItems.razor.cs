using Microsoft.AspNetCore.Components;
using TFGCalculator.Models;
using TFGCalculator.Services;
using TFGCalculator.Shared;

namespace TFGCalculator.Pages;

public partial class ModpackItems : ComponentBase, IDisposable
{
    [Parameter] public string ModpackId { get; set; } = "";

    [Inject] private ItemService ItemSvc { get; set; } = default!;
    [Inject] private RecipeService RecipeSvc { get; set; } = default!;
    [Inject] private NavigationManager Nav { get; set; } = default!;
    [Inject] private LocalizationService Loc { get; set; } = default!;
    [Inject] private StorageService Storage { get; set; } = default!;

    private List<TreeConfig> _trees = new();
    private List<GameItem> _filtered = new();
    private SearchDropdown? _dd;
    private int _addIdx = -1, _editIdx = -1;

    public static List<ProductionRequest>? PendingRequests { get; set; }
    public static string? PendingModpackId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Loc.OnLanguageChanged += StateHasChanged;
        _filtered = ItemSvc.GetByModpack(ModpackId);

        try
        {
            var saved = await Storage.LoadAsync<SavedTreeData>($"trees_{ModpackId}");
            if (saved?.Trees?.Any() == true)
            {
                _trees = saved.Trees;
                foreach (var t in _trees)
                {
                    t.ModpackId = ModpackId;
                    // Remove requests with items that no longer exist
                    t.Requests.RemoveAll(r => r.Item == null || string.IsNullOrEmpty(r.Item.Id));
                    foreach (var r in t.Requests)
                    {
                        var it = ItemSvc.GetById(ModpackId, r.Item.Id);
                        if (it != null) r.Item = it;
                    }
                }
            }
        }
        catch
        {
            // If saved data is corrupt, ignore
        }

        if (_trees.Count == 0)
            _trees.Add(new TreeConfig { Name = "Tree 1", ModpackId = ModpackId });
    }

    private async Task Save() =>
        await Storage.SaveAsync($"trees_{ModpackId}", new SavedTreeData { Trees = _trees });

    private void SearchItem(string q) => _filtered = ItemSvc.Search(ModpackId, q);
    private void StartAdd(int i) { _addIdx = i; _filtered = ItemSvc.GetByModpack(ModpackId); }

    private async Task AddItem(int ti, GameItem item)
    {
        if (_trees[ti].Requests.Any(r => r.Item.Id == item.Id)) return;
        _trees[ti].Requests.Add(new ProductionRequest { Item = item, AmountPerSecond = 1.0 });
        _addIdx = -1; _dd?.Close(); await Save();
    }

    private async Task RemoveItem(int ti, int ii) { _trees[ti].Requests.RemoveAt(ii); await Save(); }

    private async Task UpdateRate(int ti, int ii, ChangeEventArgs e)
    {
        if (double.TryParse(e.Value?.ToString(), out var v) && v > 0)
        { _trees[ti].Requests[ii].AmountPerSecond = v; await Save(); }
    }

    private async Task UpdateMachines(int ti, int ii, ChangeEventArgs e)
    {
        if (double.TryParse(e.Value?.ToString(), out var v) && v > 0)
        { _trees[ti].Requests[ii].MachineCountValue = v; await Save(); }
    }

    private async Task ChangeRateType(int ti, int ii, ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out var v))
        { _trees[ti].Requests[ii].RateType = (RateType)v; await Save(); }
    }

    private async Task AddTree()
    {
        _trees.Add(new TreeConfig { Name = $"Tree {_trees.Count + 1}", ModpackId = ModpackId });
        await Save();
    }

    private async Task RemoveTree(int i)
    {
        _trees.RemoveAt(i);
        if (_trees.Count == 0) _trees.Add(new TreeConfig { Name = "Tree 1", ModpackId = ModpackId });
        await Save();
    }

    private async Task FinishRename(int i, ChangeEventArgs e)
    {
        var n = e.Value?.ToString()?.Trim();
        if (!string.IsNullOrEmpty(n)) _trees[i].Name = n;
        _editIdx = -1;
        await Save();
    }

    private async Task GoToTree(int ti)
    {
        var tree = _trees[ti];
        if (!tree.Requests.Any()) return;

        var requests = new List<ProductionRequest>();
        foreach (var req in tree.Requests)
        {
            var pr = new ProductionRequest
            {
                Item = req.Item,
                RateType = req.RateType,
                MachineCountValue = req.MachineCountValue,
                AmountPerSecond = req.AmountPerSecond
            };
            if (req.RateType == RateType.MachineCount)
            {
                var recipe = RecipeSvc.FindRecipeForOutput(ModpackId, req.Item.Id);
                if (recipe != null)
                {
                    double durSec = recipe.DurationTicks / 20.0;
                    double opsPerSec = durSec > 0 ? 1.0 / durSec : 0;
                    var outItem = recipe.Outputs.First(o => o.ItemId == req.Item.Id);
                    pr.AmountPerSecond = opsPerSec * outItem.Amount * req.MachineCountValue;
                }
            }
            requests.Add(pr);
        }

        PendingRequests = requests;
        PendingModpackId = ModpackId;

        await Storage.SaveAsync("lastCalc", new SavedCalculationState
        {
            ModpackId = ModpackId,
            Requests = tree.Requests.Select(r => new SavedRequestItem
            {
                ItemId = r.Item.Id,
                AmountPerSecond = r.AmountPerSecond,
                RateType = (int)r.RateType,
                MachineCountValue = r.MachineCountValue
            }).ToList()
        });

        Nav.NavigateTo("/result");
    }

    public void Dispose() => Loc.OnLanguageChanged -= StateHasChanged;
}