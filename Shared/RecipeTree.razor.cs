using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

    private List<CalcTreeNode>? _flatNodes;
    private DotNetObjectReference<RecipeTree>? _selfRef;
    private bool _initialized;
    private string? _openDropdownNodeId;

    private string PosKey => $"nodePos_{ModpackId}";
    private string ArrKey => $"arrOv_{ModpackId}";
    private string ChoiceKey => $"recipeChoices_{ModpackId}";

    protected override void OnInitialized()
    {
        Loc.OnLanguageChanged += OnLangChanged;
    }

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
            if (!string.IsNullOrEmpty(savedPos))
                await JS.InvokeVoidAsync("loadNodePositions", savedPos);

            var savedArr = await Storage.LoadRawAsync(ArrKey);
            if (!string.IsNullOrEmpty(savedArr))
                await JS.InvokeVoidAsync("loadArrowOverrides", savedArr);

            // Delay slightly to ensure DOM is fully ready
            await JS.InvokeVoidAsync("initTreePanZoomDelayed", "tree-pan-container");
            _initialized = true;
        }

        if (_initialized && _flatNodes != null)
        {
            var layout = CalculationService.ComputeInitialLayout(Nodes ?? new());
            foreach (var kv in layout)
                await JS.InvokeVoidAsync("setInitialNodePosition", kv.Key, kv.Value[0], kv.Value[1]);

            foreach (var node in _flatNodes)
                await JS.InvokeVoidAsync("initNodeDrag", node.NodeId);

            var connections = CalcSvc.BuildArrowConnections(ModpackId, Nodes ?? new());
            await JS.InvokeVoidAsync("setArrowConnections", connections);
        }
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

    [JSInvokable]
    public async Task SaveNodePositions(string json) => await Storage.SaveRawAsync(PosKey, json);
    [JSInvokable]
    public async Task SaveArrowOverrides(string json) => await Storage.SaveRawAsync(ArrKey, json);
    [JSInvokable]
    public void CloseDropdowns()
    {
        if (_openDropdownNodeId != null) { _openDropdownNodeId = null; StateHasChanged(); }
    }

    private async Task HandleChanged()
    {
        _openDropdownNodeId = null;
        _flatNodes = Nodes != null ? CalculationService.FlattenTree(Nodes) : null;
        await OnTreeChanged.InvokeAsync();
        if (Nodes != null)
        {
            var choices = CalculationService.CollectRecipeChoices(Nodes);
            await Storage.SaveAsync(ChoiceKey, choices);
        }
    }

    public void Dispose() { Loc.OnLanguageChanged -= OnLangChanged; _selfRef?.Dispose(); }
}