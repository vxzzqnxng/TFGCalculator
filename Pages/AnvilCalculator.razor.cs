using Microsoft.AspNetCore.Components;
using TFGCalculator.Models;
using TFGCalculator.Services;
using TFGCalculator.Shared;

namespace TFGCalculator.Pages;

public class AnvilBlock
{
    public AnvilRecipe? Selected { get; set; }
    public List<AnvilActionInfo>? Solution { get; set; }
    public List<AnvilRecipe> Filtered { get; set; } = new();
    public SearchDropdown? Dropdown { get; set; }
}

public partial class AnvilCalculator : ComponentBase, IDisposable
{
    [Inject] private AnvilService AnvilSvc { get; set; } = default!;
    [Inject] private ItemService ItemSvc { get; set; } = default!;
    [Inject] private LocalizationService Loc { get; set; } = default!;
    [Inject] private StorageService Storage { get; set; } = default!;

    private const string ModpackId = "tfg-0.12.3";
    private const string SaveKey = "anvilBlocks";
    private List<AnvilBlock> _blocks = new();

    protected override async Task OnInitializedAsync()
    {
        await ItemSvc.EnsureLoadedAsync(ModpackId);
        Loc.OnLanguageChanged += StateHasChanged;

        var savedIds = await Storage.LoadAsync<List<string>>(SaveKey);
        if (savedIds != null && savedIds.Count > 0)
        {
            foreach (var id in savedIds)
            {
                var r = AnvilSvc.GetAll().FirstOrDefault(x => x.Id == id);
                var blk = new AnvilBlock { Filtered = AnvilSvc.GetAll() };
                if (r != null) { blk.Selected = r; blk.Solution = AnvilSvc.Solve(r); }
                _blocks.Add(blk);
            }
        }
        if (_blocks.Count == 0) _blocks.Add(new AnvilBlock { Filtered = AnvilSvc.GetAll() });
    }

    private void OnSearch(int idx, string q)
    {
        _blocks[idx].Filtered = AnvilSvc.Search(ModpackId, q);
    }

    private async Task SelectRecipe(int idx, AnvilRecipe r)
    {
        _blocks[idx].Selected = r;
        _blocks[idx].Solution = AnvilSvc.Solve(r);
        _blocks[idx].Dropdown?.Close();
        await Save();
    }

    private async Task ClearSelection(int idx)
    {
        _blocks[idx].Selected = null;
        _blocks[idx].Solution = null;
        _blocks[idx].Filtered = AnvilSvc.GetAll();
        await Save();
    }

    private async Task AddBlock()
    {
        _blocks.Add(new AnvilBlock { Filtered = AnvilSvc.GetAll() });
        await Save();
    }

    private async Task RemoveBlock(int idx)
    {
        if (_blocks.Count > 1) _blocks.RemoveAt(idx);
        await Save();
    }

    private async Task Save()
    {
        var ids = _blocks.Select(b => b.Selected?.Id ?? "").ToList();
        await Storage.SaveAsync(SaveKey, ids);
    }

    public void Dispose() => Loc.OnLanguageChanged -= StateHasChanged;
}