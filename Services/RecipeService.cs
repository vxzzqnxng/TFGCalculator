using System.Net.Http.Json;
using TFGCalculator.Models;

public class RecipeService
{
    private readonly HttpClient _http;
    private readonly Dictionary<string, List<Recipe>> _recipes = new();
    private readonly Dictionary<string, bool> _loaded = new();
    private Dictionary<string, bool> _loading = new();
    public RecipeService(HttpClient http) { _http = http; }

    public async Task EnsureLoadedAsync(string modpackId)
    {
        if (_loaded.ContainsKey(modpackId)) return;
        _loaded[modpackId] = true;

        var files = new[] {
            "chemical_reactor",
            "large_chemical_reactor",
            "centrifuge",
            "electrolyzer",
            "mixer",
            "distillery"
        };

        var all = new List<Recipe>();

        foreach (var f in files)
        {
            try
            {
                var recipes = await _http.GetFromJsonAsync<List<Recipe>>(
                    $"data/{modpackId}/recipes/{f}.json",
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (recipes != null && recipes.Any()) all.AddRange(recipes);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[RecipeService] Failed to load {f}.json: {ex.Message}");
            }
        }

        _recipes[modpackId] = all;
    }

    // Пример для нового рецепта: (Жидкость в В)
    // Id: "",
    // MachineId: "",
    // MachineNameRu: "",
    // MachineNameEn: "",
    // MachineIconPath: "",
    // Inputs: {},
    // Catalysts: {},
    // Outputs: {},
    // EnergyPerTick: 0,
    // DurationTicks: 0,
    // PrimaryEnergyType: Energytype.(FE,EUt,AE,HUt),
    // UsesHeatUnit: 0,
    // HeatPerTick: 0,
    // MinTierLevel: 0;
    // CoilMachineType: CoilMachineType.(0,1,2,3,4),
    // MinCoilLevel: 0,
    // MinTemperature: 0,
    // SupportsCoils: true/false,
    // DurationTicks: 0

    public List<Recipe> GetByModpack(string modpackId) =>
        _recipes.TryGetValue(modpackId, out var r) ? r : new();

    public Recipe? FindRecipeForOutput(string modpackId, string itemId) =>
        GetByModpack(modpackId).FirstOrDefault(r => r.Outputs.Any(o => o.ItemId == itemId));

    public List<Recipe> FindAllRecipesForOutput(string modpackId, string itemId) =>
        GetByModpack(modpackId).Where(r => r.Outputs.Any(o => o.ItemId == itemId)).ToList();
}