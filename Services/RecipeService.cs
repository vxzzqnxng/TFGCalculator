namespace TFGCalculator.Services;

using System.Collections.Generic;
using TFGCalculator.Models;

public class RecipeService
{
    /// Все рецепты, сгруппированные по модпаку.
    /// Для каждого рецепта указывается механизм, входы, выходы, энергия, длительность и т.д.
    private readonly Dictionary<string, List<Recipe>> _recipes = new()
    {
        ["tfg-0.12.3"] = new List<Recipe>
        {
            // ===================================================================
            //                           Химический реактор
            // ===================================================================
            new Recipe
            {
                Id = "platinum_group_sludge_dust_1",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "purified_chalcopyrite_ore", Amount = 2 },
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 0.1 },
                },
                Outputs = new() { 
                    new RecipeItem { ItemId = "platinum_group_sludge_dust", Amount = 2 },
                    new RecipeItem { ItemId = "sulfuric_copper_solution_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 50,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "platinum_group_sludge_dust_2",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "purified_bornite_ore", Amount = 2 },
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 0.1 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "platinum_group_sludge_dust", Amount = 2 },
                    new RecipeItem { ItemId = "sulfuric_copper_solution_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 50,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "platinum_group_sludge_dust_3",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "purified_chalcocite_ore", Amount = 2 },
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 0.1 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "platinum_group_sludge_dust", Amount = 2 },
                    new RecipeItem { ItemId = "sulfuric_copper_solution_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 50,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "platinum_group_sludge_dust_4",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "purified_tetrahedrite_ore", Amount = 2 },
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 0.1 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "platinum_group_sludge_dust", Amount = 2 },
                    new RecipeItem { ItemId = "sulfuric_copper_solution_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 50,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "platinum_group_sludge_dust_5",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "purified_pentlandite_ore", Amount = 2 },
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 0.1 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "platinum_group_sludge_dust", Amount = 2 },
                    new RecipeItem { ItemId = "sulfuric_nickel_solution_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 50,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "platinum_group_sludge_dust_6",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "purified_cooperite_ore", Amount = 2 },
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 0.1 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "platinum_group_sludge_dust", Amount = 4 },
                    new RecipeItem { ItemId = "sulfuric_nickel_solution_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 50,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "ammonia",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "hydrogen_fluid", Amount = 3 },
                    new RecipeItem { ItemId = "nitrogen_fluid", Amount = 1 },
                },
                Catalysts = new() { new RecipeItem { ItemId = "programmed_circuit_1", Amount = 1 } },
                Outputs = new() {
                    new RecipeItem { ItemId = "ammonia_fluid", Amount = 1 }
                },
                EnergyPerTick = 384,
                DurationTicks = 320,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 4
            },
            new Recipe
            {
                Id = "nitric_oxide",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "oxygen_fluid", Amount = 5 },
                    new RecipeItem { ItemId = "ammonia_fluid", Amount = 2 }
                },
                Catalysts = new() { new RecipeItem { ItemId = "programmed_circuit_1", Amount = 1 } },
                Outputs = new() {
                    new RecipeItem { ItemId = "nitric_oxide_fluid", Amount = 2 },
                    new RecipeItem { ItemId = "water_fluid", Amount = 3 },
                },
                EnergyPerTick = 30,
                DurationTicks = 160,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "nitrogen_dioxide",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "oxygen_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "nitric_oxide_fluid", Amount = 1 }
                },
                Catalysts = new() { new RecipeItem { ItemId = "programmed_circuit_1", Amount = 1 } },
                Outputs = new() {
                    new RecipeItem { ItemId = "nitrogen_dioxide_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 160,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "nitric_acid",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "nitrogen_dioxide_fluid", Amount = 3 },
                    new RecipeItem { ItemId = "water_fluid", Amount = 1 },
                },
                Catalysts = new() { new RecipeItem { ItemId = "programmed_circuit_1", Amount = 1 } },
                Outputs = new() {
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 2 },
                    new RecipeItem { ItemId = "nitric_oxide_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 240,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "nitric_acid_2",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "water_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "oxygen_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "nitrogen_dioxide_fluid", Amount = 2 },
                },
                Catalysts = new() { new RecipeItem { ItemId = "programmed_circuit_3", Amount = 1 } },
                Outputs = new() {
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 2 }
                },
                EnergyPerTick = 30,
                DurationTicks = 240,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "palladium_from_platinum_sludge",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "palladium_raw_dust", Amount = 5 },
                    new RecipeItem { ItemId = "hydrochloric_acid_fluid", Amount = 1 }
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "palladium_dust", Amount = 1 },
                    new RecipeItem { ItemId = "ammonium_chloride_dust", Amount = 2 }
                },
                EnergyPerTick = 120,
                DurationTicks = 200,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 3
            },
            new Recipe
            {
                Id = "sulfuric_acid",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "sulfur_trioxide_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "water_fluid", Amount = 1 }
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "sulfuric_acid_fluid", Amount = 1 }
                },
                EnergyPerTick = 7,
                DurationTicks = 160,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "ruthenium_tetroxide",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "inert_metal_mixture_dust", Amount = 6 },
                    new RecipeItem { ItemId = "sulfuric_acid_fluid", Amount = 1.5 }
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "ruthenium_tetroxide_dust", Amount = 5 },
                    new RecipeItem { ItemId = "rhodium_sulfate_fluid", Amount = 0.5 },
                    new RecipeItem { ItemId = "hydrogen_fluid", Amount = 3 }
                },
                EnergyPerTick = 1920,
                DurationTicks = 450,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 5
            },
            new Recipe
            {
                Id = "ruthenium_dust",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "ruthenium_tetroxide_dust", Amount = 5 },
                    new RecipeItem { ItemId = "carbon_dust", Amount = 2 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "ruthenium_dust", Amount = 1 },
                    new RecipeItem { ItemId = "carbon_dioxide_fluid", Amount = 2 }
                },
                EnergyPerTick = 120,
                DurationTicks = 200,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 3
            },
            new Recipe
            {
                Id = "iridium_dust",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "iridium_chloride_dust", Amount = 4 },
                    new RecipeItem { ItemId = "hydrogen_fluid", Amount = 3 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "iridium_dust", Amount = 1 },
                    new RecipeItem { ItemId = "hydrochloric_acid_fluid", Amount = 3 }
                },
                EnergyPerTick = 30,
                DurationTicks = 100,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "osmium_dust",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "osmium_tetroxide_dust", Amount = 5 },
                    new RecipeItem { ItemId = "hydrogen_fluid", Amount = 8 }
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "osmium_dust", Amount = 1 },
                    new RecipeItem { ItemId = "water_fluid", Amount = 4 }
                },
                EnergyPerTick = 30,
                DurationTicks = 200,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "hydrochloric_acid_fluid",
                MachineId = "chemical_reactor",
                MachineNameRu = "Химический реактор",
                MachineNameEn = "Chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "chlorine_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "hydrogen_fluid", Amount = 1 }
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "hydrochloric_acid_fluid", Amount = 1 }
                },
                EnergyPerTick = 7,
                DurationTicks = 60,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },

            // ===================================================================
            //                       Большой химический реактор
            // ===================================================================
            new Recipe
            {
                Id = "iridium_metal_residue_dust",
                MachineId = "large_chemical_reactor",
                MachineNameRu = "Большой химический реактор",
                MachineNameEn = "Large chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "rarest_metal_mixture_dust", Amount = 7 },
                    new RecipeItem { ItemId = "hydrochloric_acid_fluid", Amount = 4 }
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "iridium_metal_residue_dust", Amount = 5 },
                    new RecipeItem { ItemId = "acidic_osmium_solution_fluid", Amount = 2 },
                    new RecipeItem { ItemId = "hydrogen_fluid", Amount = 3 }
                },
                EnergyPerTick = 7680,
                DurationTicks = 400,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 6
            },
            new Recipe
            {
                Id = "nitric_acid_3",
                MachineId = "large_chemical_reactor",
                MachineNameRu = "Большой химический реактор",
                MachineNameEn = "Large chemical reactor",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "nitrogen_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "hydrogen_fluid", Amount = 3 },
                    new RecipeItem { ItemId = "oxygen_fluid", Amount = 4 }
                },
                Catalysts = new() { new RecipeItem { ItemId = "programmed_circuit_24", Amount = 1 } },
                Outputs = new() {
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "water_fluid", Amount = 1 }
                },
                EnergyPerTick = 480,
                DurationTicks = 320,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 4
            },

            // ===================================================================
            //                               Центрифуга
            // ===================================================================
            new Recipe
            {
                Id = "platinum_sludge_to_rare_metals",
                MachineId = "centrifuge",
                MachineNameRu = "Центрифуга",
                MachineNameEn = "Centrifuge",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "platinum_group_sludge_dust", Amount = 6 },
                    new RecipeItem { ItemId = "aqua_regia_fluid", Amount = 1.2 }
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "platinum_raw_dust", Amount = 3 },
                    new RecipeItem { ItemId = "palladium_raw_dust", Amount = 3 },
                    new RecipeItem { ItemId = "inert_metal_mixture_dust", Amount = 2 },
                    new RecipeItem { ItemId = "rarest_metal_mixture_dust", Amount = 1 },
                    new RecipeItem { ItemId = "platinum_sludge_residue_dust", Amount = 2 }
                },
                EnergyPerTick = 480,
                DurationTicks = 500,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 4
            },
            new Recipe
            {
                Id = "iridium_chloride_dust",
                MachineId = "centrifuge",
                MachineNameRu = "Центрифуга",
                MachineNameEn = "Centrifuge",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "iridium_metal_residue_dust", Amount = 5 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "iridium_chloride_dust", Amount = 4 },
                    new RecipeItem { ItemId = "platinum_sludge_residue_dust", Amount = 1 }
                },
                EnergyPerTick = 120,
                DurationTicks = 200,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 3
            },
            new Recipe
            {
                Id = "platinum_sludge_residue_recycling",
                MachineId = "centrifuge",
                MachineNameRu = "Центрифуга",
                MachineNameEn = "Centrifuge",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "platinum_sludge_residue_dust", Amount = 5 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "silicon_dioxide_dust", Amount = 2 },
                    new RecipeItem { ItemId = "gold_dust", Amount = 3 }
                },
                EnergyPerTick = 30,
                DurationTicks = 938,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },

            // ===================================================================
            //                              Электролизёр
            // ===================================================================
            new Recipe
            {
                Id = "platinum_dust",
                MachineId = "electrolyzer",
                MachineNameRu = "Электролизёр",
                MachineNameEn = "Electrolyer",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "platinum_raw_dust", Amount = 3 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "platinum_dust", Amount = 1 },
                    new RecipeItem { ItemId = "chlorine_fluid", Amount = 0.8 }
                },
                EnergyPerTick = 120,
                DurationTicks = 100,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 3
            },
            new Recipe
            {
                Id = "hydrochloric_acid_and_ammonia",
                MachineId = "electrolyzer",
                MachineNameRu = "Электролизёр",
                MachineNameEn = "Electrolyer",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "ammonium_chloride_dust", Amount = 2 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "ammonia_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "hydrochloric_acid_fluid", Amount = 1 }
                },
                EnergyPerTick = 30,
                DurationTicks = 20,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "rhodium_sulfate_recycling",
                MachineId = "electrolyzer",
                MachineNameRu = "Электролизёр",
                MachineNameEn = "Electrolyer",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "rhodium_sulfate_fluid", Amount = 1 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "rhodium_dust", Amount = 2 },
                    new RecipeItem { ItemId = "oxygen_fluid", Amount = 3 },
                    new RecipeItem { ItemId = "sulfur_trioxide_fluid", Amount = 3 }
                },
                EnergyPerTick = 120,
                DurationTicks = 100,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 3
            },
            new Recipe
            {
                Id = "sulfuric_copper_solution",
                MachineId = "electrolyzer",
                MachineNameRu = "Электролизёр",
                MachineNameEn = "Electrolyer",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "sulfuric_copper_solution_fluid", Amount = 1 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "copper_dust", Amount = 1 },
                    new RecipeItem { ItemId = "oxygen_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "sulfuric_acid_fluid", Amount = 1 }
                },
                EnergyPerTick = 60,
                DurationTicks = 84,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 3
            },
            new Recipe
            {
                Id = "sulfuric_nickel_solution",
                MachineId = "electrolyzer",
                MachineNameRu = "Электролизёр",
                MachineNameEn = "Electrolyer",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "sulfuric_nickel_solution_fluid", Amount = 1 },
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "nickel_dust", Amount = 1 },
                    new RecipeItem { ItemId = "oxygen_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "sulfuric_acid_fluid", Amount = 1 }
                },
                EnergyPerTick = 60,
                DurationTicks = 84,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 3
            },
            // ===================================================================
            //                              Миксер
            // ===================================================================
            new Recipe
            {
                Id = "aqua_regia",
                MachineId = "mixer",
                MachineNameRu = "Миксер",
                MachineNameEn = "Mixer",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "nitric_acid_fluid", Amount = 1 },
                    new RecipeItem { ItemId = "hydrochloric_acid_fluid", Amount = 2 }
                },
                Outputs = new() {
                    new RecipeItem { ItemId = "aqua_regia_fluid", Amount = 3 }
                },
                EnergyPerTick = 30,
                DurationTicks = 30,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            // ===================================================================
            //                            Дистиллятор
            // ===================================================================
            new Recipe
            {
                Id = "acidic_osmium_solution_recycling_1",
                MachineId = "distillery",
                MachineNameRu = "Дистиллятор",
                MachineNameEn = "Distillery",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "acidic_osmium_solution_fluid", Amount = 0.4 },
                },
                Catalysts = new() { new RecipeItem { ItemId = "programmed_circuit_1", Amount = 1 } },
                Outputs = new() {
                    new RecipeItem { ItemId = "osmium_tetroxide_dust", Amount = 1 },
                    new RecipeItem { ItemId = "hydrochloric_acid_fluid", Amount = 0.2 },
                },
                EnergyPerTick = 30,
                DurationTicks = 160,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },
            new Recipe
            {
                Id = "acidic_osmium_solution_recycling_1",
                MachineId = "distillery",
                MachineNameRu = "Дистиллятор",
                MachineNameEn = "Distillery",
                Inputs = new()
                {
                    new RecipeItem { ItemId = "acidic_osmium_solution_fluid", Amount = 0.4 },
                },
                Catalysts = new() { new RecipeItem { ItemId = "programmed_circuit_2", Amount = 1 } },
                Outputs = new() {
                    new RecipeItem { ItemId = "osmium_tetroxide_dust", Amount = 1 },
                    new RecipeItem { ItemId = "water_fluid", Amount = 0.2 },
                },
                EnergyPerTick = 30,
                DurationTicks = 160,
                PrimaryEnergyType = EnergyType.EUt,
                MinTierLevel = 2
            },

            // Пример для нового рецепта: (Жидкость в В)
            // Id = "",
            // MachineId = "",
            // MachineNameRu = "",
            // MachineNameEn = "",
            // MachineIconPath = "",
            // Inputs = new() {},
            // Catalysts = new() {},
            // Outputs = new() {},
            // EnergyPerTick = 0,
            // DurationTicks = 0,
            // PrimaryEnergyType = Energytype.(FE,EUt,AE,HUt),
            // UsesHeatUnit = 0,
            // HeatPerTick = 0,
            // MinTierLevel = 0;
            // CoilMachineType = CoilMachineType.(0,1,2,3,4),
            // MinCoilLevel = 0,
            // MinTemperature = 0,
            // SupportsCoils = true/false,
            // DurationTicks = 0
        }
    };

    public List<Recipe> GetByModpack(string modpackId)
    {
        return _recipes.TryGetValue(modpackId, out var recipes) ? recipes : new();
    }

    public Recipe? FindRecipeForOutput(string modpackId, string itemId)
    {
        return GetByModpack(modpackId)
            .FirstOrDefault(r => r.Outputs.Any(o => o.ItemId == itemId));
    }

    public List<Recipe> FindAllRecipesForOutput(string modpackId, string itemId)
    {
        return GetByModpack(modpackId)
            .Where(r => r.Outputs.Any(o => o.ItemId == itemId))
            .ToList();
    }
}