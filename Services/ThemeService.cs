using Microsoft.JSInterop;

namespace TFGCalculator.Services;

public class ThemeService
{
    private readonly IJSRuntime _js;
    public event Action? OnThemeChanged;
    public bool IsDark { get; private set; }
    public string BodyClass => IsDark ? "dark-theme" : "light-theme";

    public ThemeService(IJSRuntime js) { _js = js; }

    public async Task InitAsync()
    {
        var saved = await _js.InvokeAsync<string?>("lsLoad", "theme");
        IsDark = saved == "dark";
    }

    public async Task ToggleAsync()
    {
        IsDark = !IsDark;
        await _js.InvokeVoidAsync("lsSave", "theme", IsDark ? "dark" : "light");
        OnThemeChanged?.Invoke();
    }
}