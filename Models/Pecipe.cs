namespace TFGCalculator.Models;

public class RecipeItem
{
    public string ItemId { get; set; } = "";
    public double Amount { get; set; }
}

public class Recipe
{
    public string Id { get; set; } = "";
    public string MachineId { get; set; } = "";
    public string MachineNameRu { get; set; } = "";
    public string MachineNameEn { get; set; } = "";
    public string MachineIconPath { get; set; } = "";

    public List<RecipeItem> Inputs { get; set; } = new();
    public List<RecipeItem> Catalysts { get; set; } = new();
    public List<RecipeItem> Outputs { get; set; } = new();

    public double EnergyPerTick { get; set; }
    public int DurationTicks { get; set; }
    public EnergyType PrimaryEnergyType { get; set; }
    public bool UsesHeatUnit { get; set; }
    public double HeatPerTick { get; set; }
    public int MinTierLevel { get; set; } = 1;

    public CoilMachineType CoilMachineType { get; set; } = CoilMachineType.None;
    public int MinCoilLevel { get; set; } = 1;

    /// <summary>Минимальная температура рецепта (только для EBF)</summary>
    public int MinTemperature { get; set; }

    public bool SupportsCoils => CoilMachineType != CoilMachineType.None;

    public string GetMachineName(string lang) => lang == "en" ? MachineNameEn : MachineNameRu;
    public double DurationSeconds => DurationTicks / 20.0;

    public string GetMachineIconUrl()
    {
        if (!string.IsNullOrEmpty(MachineIconPath)) return MachineIconPath;
        return $"images/machines/{MachineId}.png";
    }
}