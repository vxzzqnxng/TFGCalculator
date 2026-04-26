using Microsoft.AspNetCore.Components;
using TFGCalculator.Models;
using TFGCalculator.Services;
using TFGCalculator.Shared;

namespace TFGCalculator.Pages;

public enum AlloyUnit { MilliBuckets = 0, Ingots = 1 }

public class AlloyOreRow
{
    public string MetalItemId { get; set; } = "";    // ид компонента (одинаковый у «раздвоенных» строк)
    public int MbPerOre { get; set; } = 16;         // сколько мБ даёт 1 единица входа
    public int ResultCount { get; set; }             // посчитанное кол-во единиц
    public double ResultMb { get; set; }             // фактические мБ
    public double ResultPercent { get; set; }        // % от итога
}

public class AlloyBlock
{
    public AlloyRecipe? SelectedAlloy { get; set; }
    public int TotalAmount { get; set; } = 144;
    public AlloyUnit Unit { get; set; } = AlloyUnit.MilliBuckets;
    public List<AlloyOreRow> Rows { get; set; } = new();
    public SearchDropdown? Dropdown { get; set; }
    public bool AlloyDropdownOpen { get; set; }
    public double ActualTotalMb { get; set; }
    public bool Feasible { get; set; }
}

public class AlloySavedBlock
{
    public string AlloyId { get; set; } = "";
    public int TotalAmount { get; set; }
    public int Unit { get; set; }
    public List<AlloyOreRow> Rows { get; set; } = new();
}

public partial class AlloyCalculator : ComponentBase, IDisposable
{
    [Inject] private AlloyService AlloySvc { get; set; } = default!;
    [Inject] private ItemService ItemSvc { get; set; } = default!;
    [Inject] private LocalizationService Loc { get; set; } = default!;
    [Inject] private StorageService Storage { get; set; } = default!;

    private const string ModpackId = "tfg-modern";
    private const string SaveKey = "alloyBlocks";

    private List<AlloyBlock> _blocks = new();
    private List<AlloyRecipe> _filteredAlloys = new();

    protected override async Task OnInitializedAsync()
    {
        await ItemSvc.EnsureLoadedAsync(ModpackId);
        Loc.OnLanguageChanged += StateHasChanged;
        _filteredAlloys = AlloySvc.GetAll();

        var saved = await Storage.LoadAsync<List<AlloySavedBlock>>(SaveKey);
        if (saved != null && saved.Count > 0)
        {
            foreach (var sb in saved)
            {
                var alloy = !string.IsNullOrEmpty(sb.AlloyId) ? AlloySvc.GetById(sb.AlloyId) : null;
                var blk = new AlloyBlock
                {
                    SelectedAlloy = alloy,
                    TotalAmount = sb.TotalAmount > 0 ? sb.TotalAmount : 144,
                    Unit = (AlloyUnit)sb.Unit,
                    Rows = sb.Rows ?? new()
                };
                if (alloy != null && blk.Rows.Count == 0)
                {
                    blk.Rows = alloy.Components
                        .Select(c => new AlloyOreRow { MetalItemId = c.MetalItemId, MbPerOre = 16 })
                        .ToList();
                }
                _blocks.Add(blk);
                Recalculate(blk);
            }
        }
        if (_blocks.Count == 0) _blocks.Add(new AlloyBlock());
    }

    private void SearchAlloy(string q) => _filteredAlloys = AlloySvc.Search(q);

    private async Task SelectAlloy(int bi, AlloyRecipe alloy)
    {
        _blocks[bi].SelectedAlloy = alloy;
        _blocks[bi].AlloyDropdownOpen = false;
        _blocks[bi].Rows = alloy.Components
            .Select(c => new AlloyOreRow { MetalItemId = c.MetalItemId, MbPerOre = 16 })
            .ToList();
        Recalculate(_blocks[bi]);
        await Save();
    }

    private async Task ToggleAlloyDropdown(int bi)
    {
        _blocks[bi].AlloyDropdownOpen = !_blocks[bi].AlloyDropdownOpen;
        _filteredAlloys = AlloySvc.GetAll();
        await Task.CompletedTask;
    }

    private async Task ChangeAmount(int bi, ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out var v) && v > 0)
        {
            _blocks[bi].TotalAmount = v;
            Recalculate(_blocks[bi]);
            await Save();
        }
    }

    private async Task ChangeUnit(int bi, ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out var v))
        {
            _blocks[bi].Unit = (AlloyUnit)v;
            Recalculate(_blocks[bi]);
            await Save();
        }
    }

    private async Task ChangeMbPerOre(int bi, int ri, ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out var v) && v > 0)
        {
            _blocks[bi].Rows[ri].MbPerOre = v;
            Recalculate(_blocks[bi]);
            await Save();
        }
    }

    private async Task DuplicateRow(int bi, int ri)
    {
        var src = _blocks[bi].Rows[ri];
        _blocks[bi].Rows.Insert(ri + 1,
            new AlloyOreRow { MetalItemId = src.MetalItemId, MbPerOre = src.MbPerOre });
        Recalculate(_blocks[bi]);
        await Save();
    }

    private async Task RemoveRow(int bi, int ri)
    {
        var block = _blocks[bi];
        if (block.SelectedAlloy == null) return;
        // Нельзя удалить последний ряд данного металла (иначе компонент исчезнет)
        var metalId = block.Rows[ri].MetalItemId;
        if (block.Rows.Count(r => r.MetalItemId == metalId) <= 1) return;
        block.Rows.RemoveAt(ri);
        Recalculate(block);
        await Save();
    }

    private async Task AddBlock() { _blocks.Add(new AlloyBlock()); await Save(); }

    private async Task RemoveBlock(int bi)
    {
        if (_blocks.Count > 1) _blocks.RemoveAt(bi);
        await Save();
    }

    private async Task Save()
    {
        var data = _blocks.Select(b => new AlloySavedBlock
        {
            AlloyId = b.SelectedAlloy?.Id ?? "",
            TotalAmount = b.TotalAmount,
            Unit = (int)b.Unit,
            Rows = b.Rows
        }).ToList();
        await Storage.SaveAsync(SaveKey, data);
    }

    public void Dispose() => Loc.OnLanguageChanged -= StateHasChanged;

    // =====================================================================
    //  SOLVER: перебор с ограничениями по процентам
    // =====================================================================
    private void Recalculate(AlloyBlock block)
    {
        // сброс
        foreach (var r in block.Rows) { r.ResultCount = 0; r.ResultMb = 0; r.ResultPercent = 0; }
        block.ActualTotalMb = 0;
        block.Feasible = false;

        if (block.SelectedAlloy == null || block.Rows.Count == 0) return;

        double targetMb = block.Unit == AlloyUnit.Ingots ? block.TotalAmount * 144 : block.TotalAmount;
        if (targetMb <= 0) return;

        // Группируем ряды по MetalItemId — на один компонент может быть несколько источников.
        var comp = block.SelectedAlloy.Components;
        var groups = block.Rows
            .Select((r, idx) => new { Row = r, Idx = idx })
            .GroupBy(x => x.Row.MetalItemId)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.Idx).ToList());

        int rowN = block.Rows.Count;
        int[] bestCounts = new int[rowN];
        double bestExcess = double.MaxValue;

        // Верхняя граница перебора: максимум столько единиц, чтобы компонент перекрывал 100% от 2× target
        int MaxCountFor(int rowIdx)
        {
            int k = Math.Max(1, block.Rows[rowIdx].MbPerOre);
            return Math.Max(2, (int)Math.Ceiling(targetMb * 2.0 / k));
        }

        int[] current = new int[rowN];
        Search(0);

        void Search(int ri)
        {
            if (ri == rowN)
            {
                double total = 0;
                for (int i = 0; i < rowN; i++) total += current[i] * block.Rows[i].MbPerOre;
                if (total < targetMb - 1e-9) return;
                // percent-check по компонентам (агрегат по всем строкам одного компонента)
                foreach (var c in comp)
                {
                    if (!groups.TryGetValue(c.MetalItemId, out var rowIds))
                    {
                        // компонент без ряда — невалидно
                        return;
                    }
                    double compMb = 0;
                    foreach (var rid in rowIds) compMb += current[rid] * block.Rows[rid].MbPerOre;
                    double pct = compMb / total * 100.0;
                    if (pct < c.MinPercent - 1e-6 || pct > c.MaxPercent + 1e-6) return;
                }
                double excess = total - targetMb;
                if (excess < bestExcess)
                {
                    Array.Copy(current, bestCounts, rowN);
                    bestExcess = excess;
                }
                return;
            }
            int max = MaxCountFor(ri);
            for (int c = 1; c <= max; c++)
            {
                current[ri] = c;
                Search(ri + 1);
                if (bestExcess == 0) return; // идеально
            }
        }

        if (bestExcess == double.MaxValue) return;

        double actualTotal = 0;
        for (int i = 0; i < rowN; i++)
        {
            block.Rows[i].ResultCount = bestCounts[i];
            block.Rows[i].ResultMb = bestCounts[i] * block.Rows[i].MbPerOre;
            actualTotal += block.Rows[i].ResultMb;
        }
        foreach (var r in block.Rows)
            r.ResultPercent = actualTotal > 0 ? r.ResultMb / actualTotal * 100.0 : 0;
        block.ActualTotalMb = actualTotal;
        block.Feasible = true;
    }
}