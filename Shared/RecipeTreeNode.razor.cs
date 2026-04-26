using Microsoft.AspNetCore.Components;
using TFGCalculator.Models;
using TFGCalculator.Services;

namespace TFGCalculator.Shared;

public partial class RecipeTreeNode : ComponentBase
{
    [Inject] private CalculationService CalcSvc { get; set; } = default!;
    [Inject] private ItemService ItemSvc { get; set; } = default!;
    [Inject] private LocalizationService Loc { get; set; } = default!;

    [Parameter] public CalcTreeNode Node { get; set; } = new();
    [Parameter] public string ModpackId { get; set; } = "";
    [Parameter] public EventCallback OnTierChangedCallback { get; set; }
    [Parameter] public EventCallback OnRecipeSelected { get; set; }
    [Parameter] public EventCallback OnStorageSelected { get; set; }
    [Parameter] public string? OpenDropdownNodeId { get; set; }
    [Parameter] public EventCallback<string> OnRequestOpenDropdown { get; set; }
    [Parameter] public EventCallback<string> OnAddAlternative { get; set; }

    private async Task AddAlternative()
    {
        await OnAddAlternative.InvokeAsync(Node.ItemId);
    }

    private bool _showTierDrop;
    private bool _showCoilDrop;

    private void OnCardClick()
    {
        _showTierDrop = false;
        _showCoilDrop = false;
        if (OpenDropdownNodeId != null) OnRequestOpenDropdown.InvokeAsync("");
    }

    private void ToggleDrop()
    {
        _showTierDrop = false;
        _showCoilDrop = false;
        OnRequestOpenDropdown.InvokeAsync(OpenDropdownNodeId == Node.NodeId ? "" : Node.NodeId);
    }

    private void ToggleTierDrop() { _showTierDrop = !_showTierDrop; _showCoilDrop = false; }
    private void ToggleCoilDrop() { _showCoilDrop = !_showCoilDrop; _showTierDrop = false; }

    private async Task SelectTier(int level)
    {
        Node.CurrentTierLevel = level;
        _showTierDrop = false;
        await OnTierChangedCallback.InvokeAsync();
    }

    private async Task SelectCoil(int level)
    {
        Node.CurrentCoilLevel = level;
        _showCoilDrop = false;
        await OnTierChangedCallback.InvokeAsync();
    }

    /// <summary>Mark recipe choice, then full rebuild via HandleChanged</summary>
    private async Task DoRecipe(Recipe r)
    {
        Node.Recipe = r;
        Node.NeedsRecipeSelection = false;
        Node.IsStorage = false;
        await OnRecipeSelected.InvokeAsync();
    }

    private async Task DoStorage()
    {
        Node.IsStorage = true;
        Node.Recipe = null;
        Node.NeedsRecipeSelection = false;
        await OnStorageSelected.InvokeAsync();
    }

    private string GetTieredMachineIcon()
    {
        if (Node.Recipe == null) return "";
        return Node.Recipe.GetTieredMachineIconUrl(Node.CurrentTierLevel);
    }

    private string GetFallbackMachineIcon()
    {
        if (Node.Recipe == null) return "";
        return Node.Recipe.GetMachineIconUrl();
    }
}