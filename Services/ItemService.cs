using System.Net.Http;
using System.Net.Http.Json;
using TFGCalculator.Models;

namespace TFGCalculator.Services;

public class ItemService
{
    private readonly HttpClient _http;
    private readonly Dictionary<string, List<GameItem>> _items = new();
    private readonly Dictionary<string, bool> _loaded = new();
    private Dictionary<string, bool> _loading = new();

    public ItemService(HttpClient http) { _http = http; }

    public async Task EnsureLoadedAsync(string modpackId)
    {
        if (_loaded.ContainsKey(modpackId)) return;
        _loaded[modpackId] = true;

        var files = new[] {
        "circuits",
        "programmed_circuits",
        "dusts",
        "dusts_impure",
        "dusts_pure",
        "dusts_tiny",
        "dusts_small",
        "ingots",
        "hot_ingots",
        "rods",
        "fluids",
        "purified_ores",
        "else",
        "double_ingots",
        "plates",
        "double_plates",
        "bolts",
        "screws",
        "tool_heads",
        "nuggets",
        "rings",
        "gears",
        "small_gears",
        "springs",
        "small_springs",
        "anvil_recipe_items",
        "long_rods"
        };
        var all = new List<GameItem>();
        foreach (var f in files)
        {
            try
            {
                var items = await _http.GetFromJsonAsync<List<GameItem>>(
                    $"data/{modpackId}/items/{f}.json",
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (items != null) all.AddRange(items);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[ItemService] Failed to load {f}.json: {ex.Message}");
            }
        }
        _items[modpackId] = all;
    }

    public List<GameItem> GetByModpack(string modpackId) =>
        _items.TryGetValue(modpackId, out var items) ? items : new();

    public List<GameItem> Search(string modpackId, string query)
    {
        var items = GetByModpack(modpackId);
        if (string.IsNullOrWhiteSpace(query)) return items;
        return items.Where(i =>
            i.NameRu.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            i.NameEn.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            i.Tag.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            i.Type.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            i.Id.Contains(query, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public GameItem? GetById(string modpackId, string itemId) =>
        GetByModpack(modpackId).FirstOrDefault(i => i.Id == itemId);
}