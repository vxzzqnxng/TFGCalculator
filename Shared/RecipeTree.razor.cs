using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using TFGCalculator.Models;
using TFGCalculator.Services;

namespace TFGCalculator.Shared;

public partial class RecipeTree : ComponentBase, IDisposable
{
    [Inject] private IJSRuntime JS { get; set; } = default!;
    [Inject] private CalculationService CalcSvc { get; set; } = default!;
    [Inject] private StorageService Storage { get; set; } = default!;
    [Inject] private LocalizationService Loc { get; set; } = default!;

    [Parameter] public List<CalcTreeNode>? Nodes { get; set; }
    [Parameter] public string ModpackId { get; set; } = "";
    [Parameter] public EventCallback OnTreeChanged { get; set; }
    [Parameter] public string TreeId { get; set; } = "";
    [Parameter] public EventCallback<string> OnAddAlternativeRoot { get; set; }

    private async Task HandleAddAlternative(string itemId)
    {
        await OnAddAlternativeRoot.InvokeAsync(itemId);
    }

    private string PosKey => string.IsNullOrEmpty(TreeId) ? $"nodePos_{ModpackId}" : $"nodePos_{ModpackId}_{TreeId}";
    private string ArrKey => string.IsNullOrEmpty(TreeId) ? $"arrOv_{ModpackId}" : $"arrOv_{ModpackId}_{TreeId}";

    private List<CalcTreeNode>? _flatNodes;
    private DotNetObjectReference<RecipeTree>? _selfRef;
    private bool _initialized;
    private string? _openDropdownNodeId;
    private string _lastAppliedHash = "";

    protected override void OnInitialized() => Loc.OnLanguageChanged += OnLangChanged;

    protected override void OnParametersSet()
    {
        _flatNodes = Nodes != null ? CalculationService.FlattenTree(Nodes) : null;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _selfRef = DotNetObjectReference.Create(this);
            await JS.InvokeVoidAsync("setBlazorTreeRef", _selfRef);

            var savedPos = await Storage.LoadRawAsync(PosKey);
            await JS.InvokeVoidAsync("loadNodePositions", savedPos ?? "");

            var savedArr = await Storage.LoadRawAsync(ArrKey);
            await JS.InvokeVoidAsync("loadArrowOverrides", savedArr ?? "");

            await JS.InvokeVoidAsync("initTreePanZoom", "tree-pan-container");
            _initialized = true;
        }

        if (!_initialized || _flatNodes == null || _flatNodes.Count == 0) return;

        var layout = CalculationService.ComputeInitialLayout(Nodes ?? new());
        if (layout.Count == 0) return;

        // Compute field size with generous buffer (user freedom)
        double maxX = 0, maxY = 0;
        foreach (var kv in layout)
        {
            maxX = Math.Max(maxX, kv.Value[0]);
            maxY = Math.Max(maxY, kv.Value[1]);
        }
        // Minimum big field + 1500px buffer around computed layout
        int fieldW = (int)Math.Max(6000, maxX + 2000);
        int fieldH = (int)Math.Max(4000, maxY + 2000);

        var arr = layout.Select(kv => new
        {
            id = kv.Key,
            x = kv.Value[0],
            y = kv.Value[1]
        }).ToArray();
        var json = JsonSerializer.Serialize(arr);
        var hash = string.Join("|", layout.Keys.OrderBy(k => k));

        bool structureChanged = hash != _lastAppliedHash;
        _lastAppliedHash = hash;

        // Collect node IDs for drag init
        var nodeIds = _flatNodes.Select(n => n.NodeId).ToArray();
        var connections = CalcSvc.BuildArrowConnections(ModpackId, Nodes ?? new());

        // Single atomic call on JS side: set field size, apply layout, init drag, draw arrows
        await JS.InvokeVoidAsync("renderTree", fieldW, fieldH, json, nodeIds, connections, structureChanged);
    }

    private void OnRequestOpenDropdown(string nodeId)
    {
        _openDropdownNodeId = string.IsNullOrEmpty(nodeId) ? null : nodeId;
        StateHasChanged();
    }

    private void OnLangChanged()
    {
        if (Nodes != null) CalcSvc.RefreshAllNames(ModpackId, Nodes);
        _flatNodes = Nodes != null ? CalculationService.FlattenTree(Nodes) : null;
        StateHasChanged();
    }

    [JSInvokable] public async Task SaveNodePositions(string json) => await Storage.SaveRawAsync(PosKey, json);
    [JSInvokable] public async Task SaveArrowOverrides(string json) => await Storage.SaveRawAsync(ArrKey, json);

    [JSInvokable]
    public void CloseDropdowns()
    {
        if (_openDropdownNodeId != null) { _openDropdownNodeId = null; StateHasChanged(); }
    }

    private async Task HandleChanged()
    {
        _openDropdownNodeId = null;
        _lastAppliedHash = ""; // Force re-apply layout
        _flatNodes = Nodes != null ? CalculationService.FlattenTree(Nodes) : null;
        await OnTreeChanged.InvokeAsync();
    }

    public void Dispose() { Loc.OnLanguageChanged -= OnLangChanged; _selfRef?.Dispose(); }
}