namespace TFGCalculator.Services;

using TFGCalculator.Models;

public class AlloyService
{
    private readonly ItemService _items;
    private readonly LocalizationService _loc;

    public AlloyService(ItemService items, LocalizationService loc)
    {
        _items = items;
        _loc = loc;
    }

    private readonly List<AlloyRecipe> _alloys = new()
    {
        new AlloyRecipe { Id = "bronze",
        ResultItemId = "bronze_fluid",
        NameRu = "Бронза",
        NameEn = "Bronze",
        Components = new()
            {
            new() { MetalItemId = "copper_fluid", MinPercent = 70, MaxPercent = 80 },
            new() {MetalItemId = "tin_fluid", MinPercent = 20, MaxPercent = 30}
            }
        },
        new AlloyRecipe { Id = "bismuth_bronze",
        ResultItemId = "bismuth_bronze_fluid",
        NameRu = "Бисмутовая бронза",
        NameEn = "Bismuth bronze",
        Components = new()
            {
            new() { MetalItemId = "zinc_fluid", MinPercent = 20, MaxPercent = 30 },
            new() { MetalItemId = "copper_fluid", MinPercent = 50, MaxPercent = 65 },
            new() { MetalItemId = "bismuth_fluid", MinPercent = 10, MaxPercent = 20 }
            }
        },
        new AlloyRecipe { Id = "black_bronze",
        ResultItemId = "black_bronze_fluid",
        NameRu = "Черная бронза",
        NameEn = "Black Bronze",
        Components = new()
            {
            new() { MetalItemId = "copper_fluid", MinPercent = 50, MaxPercent = 70 },
            new() { MetalItemId = "silver_fluid", MinPercent = 10, MaxPercent = 25 },
            new() { MetalItemId = "gold_fluid", MinPercent = 10, MaxPercent = 25 }
            }
        },
        new AlloyRecipe { Id = "brass",
        ResultItemId = "brass_fluid",
        NameRu = "Латунь",
        NameEn = "Brass",
        Components = new()
            {
            new() { MetalItemId = "copper_fluid", MinPercent = 70, MaxPercent = 80 },
            new() { MetalItemId = "zinc_fluid", MinPercent = 20, MaxPercent = 30 }
            }
        },
        new AlloyRecipe { Id = "rose_gold",
        ResultItemId = "rose_gold_fluid",
        NameRu = "Розовое золото",
        NameEn = "Rose Gold",
        Components = new()
            {
            new() { MetalItemId = "copper_fluid", MinPercent = 15, MaxPercent = 30 },
            new() { MetalItemId = "gold_fluid", MinPercent = 70, MaxPercent = 85 }
            }
        },
        new AlloyRecipe { Id = "sterling_silver",
        ResultItemId = "sterling_silver_fluid",
        NameRu = "Стерлинговое серебро",
        NameEn = "Sterling Silver",
        Components = new()
            {
            new() { MetalItemId = "copper_fluid", MinPercent = 20, MaxPercent = 40 },
            new() { MetalItemId = "silver_fluid", MinPercent = 60, MaxPercent = 80 }
            }
        },
        new AlloyRecipe { Id = "weak_red_steel",
        ResultItemId = "weak_red_steel_fluid",
        NameRu = "Сырая красная сталь",
        NameEn = "Weak Red Steel",
        Components = new()
            {
            new() { MetalItemId = "brass_fluid", MinPercent = 10, MaxPercent = 15 },
            new() { MetalItemId = "rose_gold_fluid", MinPercent = 10, MaxPercent = 15 },
            new() { MetalItemId = "black_steel_fluid", MinPercent = 50, MaxPercent = 55 },
            new() { MetalItemId = "steel_fluid", MinPercent = 20, MaxPercent = 25 }
            }
        },
        new AlloyRecipe { Id = "weak_blue_steel",
        ResultItemId = "weak_blue_steel_fluid",
        NameRu = "Сырая синяя сталь",
        NameEn = "Weak Blue Steel",
        Components = new()
            {
            new() { MetalItemId = "bismuth_bronze_fluid", MinPercent = 10, MaxPercent = 15 },
            new() { MetalItemId = "sterling_silver_fluid", MinPercent = 10, MaxPercent = 15 },
            new() { MetalItemId = "black_steel_fluid", MinPercent = 50, MaxPercent = 55 },
            new() { MetalItemId = "steel_fluid", MinPercent = 20, MaxPercent = 25 }
            }
        },
        new AlloyRecipe { Id = "weak_black_steel",
        ResultItemId = "weak_black_steel_fluid",
        NameRu = "Сырая сталь",
        NameEn = "Weak Steel",
        Components = new()
            {
            new() { MetalItemId = "black_bronze_fluid", MinPercent = 15, MaxPercent = 25 },
            new() { MetalItemId = "nickel_fluid", MinPercent = 15, MaxPercent = 25 },
            new() { MetalItemId = "steel_fluid", MinPercent = 50, MaxPercent = 70 }
            }
        },
        new AlloyRecipe { Id = "tin_alloy",
        ResultItemId = "tin_alloy_fluid",
        NameRu = "Оловянный сплав",
        NameEn = "Tin Alloy",
        Components = new()
            {
            new() { MetalItemId = "iron_fluid", MinPercent = 45, MaxPercent = 55 },
            new() { MetalItemId = "tin_fluid", MinPercent = 45, MaxPercent = 55 }
            }
        },
        new AlloyRecipe { Id = "cobalt_brass",
        ResultItemId = "cobalt_brass_fluid",
        NameRu = "Кобальтовая латунь",
        NameEn = "Cobalt Brass",
        Components = new()
            {
            new() { MetalItemId = "brass_fluid", MinPercent = 74, MaxPercent = 81 },
            new() { MetalItemId = "cobalt_fluid", MinPercent = 8, MaxPercent = 14 },
            new() { MetalItemId = "aluminium_silicate_fluid", MinPercent = 8, MaxPercent = 14 }
            }
        },
        new AlloyRecipe { Id = "invar",
        ResultItemId = "invar_fluid",
        NameRu = "Инвар",
        NameEn = "Invar",
        Components = new()
            {
            new() { MetalItemId = "iron_fluid", MinPercent = 60, MaxPercent = 70 },
            new() { MetalItemId = "nickel_fluid", MinPercent = 30, MaxPercent = 40 }
            }
        },
        new AlloyRecipe { Id = "red_alloy",
        ResultItemId = "red_alloy_fluid",
        NameRu = "Красный сплав",
        NameEn = "Red Alloy",
        Components = new()
            {
            new() { MetalItemId = "redstone_fluid", MinPercent = 75, MaxPercent = 85 },
            new() {MetalItemId = "copper_fluid", MinPercent = 15, MaxPercent = 25}
            }
        },
        new AlloyRecipe { Id = "potin",
        ResultItemId = "potin_fluid",
        NameRu = "Потин",
        NameEn = "Potin",
        Components = new()
            {
            new() { MetalItemId = "copper_fluid", MinPercent = 63, MaxPercent = 69 },
            new() { MetalItemId = "lead_fluid", MinPercent = 8, MaxPercent = 14 },
            new() { MetalItemId = "tin_fluid", MinPercent = 19, MaxPercent = 25 }
            }
        },
    };

    public List<AlloyRecipe> GetAll() => _alloys;
    public AlloyRecipe? GetById(string id) => _alloys.FirstOrDefault(a => a.Id == id);

    public List<AlloyRecipe> Search(string q)
    {
        if (string.IsNullOrWhiteSpace(q)) return _alloys;
        return _alloys.Where(a =>
            a.NameRu.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            a.NameEn.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            a.Id.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}