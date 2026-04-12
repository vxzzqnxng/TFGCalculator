using Microsoft.AspNetCore.Components;
using TFGCalculator.Models;

namespace TFGCalculator.Shared;

public partial class ProductionItem : ComponentBase
{
    [Parameter] public ProductionRequest Request { get; set; } = new();
    [Parameter] public EventCallback OnRemove { get; set; }
    [Parameter] public EventCallback<double> OnRateChange { get; set; }

    private async Task OnRateChanged(ChangeEventArgs e)
    {
        if (double.TryParse(e.Value?.ToString(), out var val) && val > 0)
        {
            Request.AmountPerSecond = val;
            await OnRateChange.InvokeAsync(val);
        }
    }

    private async Task OnRemoveClicked()
    {
        await OnRemove.InvokeAsync();
    }
}