using Microsoft.JSInterop;
using System.Text.Json;

namespace TFGCalculator.Services;

public class StorageService
{
    private readonly IJSRuntime _js;
    public StorageService(IJSRuntime js) { _js = js; }

    public async Task SaveAsync<T>(string key, T data)
    {
        var json = JsonSerializer.Serialize(data);
        await _js.InvokeVoidAsync("lsSave", key, json);
    }

    public async Task<T?> LoadAsync<T>(string key)
    {
        var json = await _js.InvokeAsync<string?>("lsLoad", key);
        if (string.IsNullOrEmpty(json)) return default;
        try { return JsonSerializer.Deserialize<T>(json); }
        catch { return default; }
    }

    public async Task SaveRawAsync(string key, string value)
    {
        await _js.InvokeVoidAsync("lsSave", key, value);
    }

    public async Task<string?> LoadRawAsync(string key)
    {
        return await _js.InvokeAsync<string?>("lsLoad", key);
    }

    public async Task RemoveAsync(string key)
    {
        await _js.InvokeVoidAsync("lsRemove", key);
    }
}