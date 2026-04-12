using Microsoft.AspNetCore.Components;

namespace TFGCalculator.Shared;

public partial class SearchDropdown : ComponentBase
{
    [Parameter] public string Label { get; set; } = "";
    [Parameter] public string Placeholder { get; set; } = "";
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public EventCallback<string> OnSearch { get; set; }
    [Parameter] public EventCallback OnOpened { get; set; }

    private bool _isOpen;
    private string _searchText = "";

    public void Open()
    {
        _isOpen = true;
        OnOpened.InvokeAsync();
    }

    public void Close()
    {
        _isOpen = false;
        StateHasChanged();
    }

    private async Task OnInput(ChangeEventArgs e)
    {
        _searchText = e.Value?.ToString() ?? "";
        _isOpen = true;
        await OnSearch.InvokeAsync(_searchText);
    }

    public void ClearSearch()
    {
        _searchText = "";
    }
}