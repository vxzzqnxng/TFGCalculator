using Microsoft.AspNetCore.Components;
using TFGCalculator.Models;
using TFGCalculator.Services;
using TFGCalculator.Shared;

namespace TFGCalculator.Pages;

public partial class Home : ComponentBase, IDisposable
{
    [Inject] private ModpackService ModpackSvc { get; set; } = default!;
    [Inject] private NavigationManager Nav { get; set; } = default!;
    [Inject] private LocalizationService Loc { get; set; } = default!;

    private SearchDropdown? _dd;
    private List<Modpack> _filtered = new();

    protected override void OnInitialized()
    {
        _filtered = ModpackSvc.GetAll();
        Loc.OnLanguageChanged += StateHasChanged;
    }

    private void OnSearch(string q) => _filtered = ModpackSvc.Search(q);

    private void Select(Modpack m) { _dd?.Close(); Nav.NavigateTo($"/modpack/{m.Id}"); }

    public void Dispose() => Loc.OnLanguageChanged -= StateHasChanged;
}