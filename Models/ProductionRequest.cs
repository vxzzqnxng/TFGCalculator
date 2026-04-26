namespace TFGCalculator.Models;

public enum RateType
{
    PerSecond = 0,
    MachineCount = 1,
    ViewOnly = 2
}

public class ProductionRequest
{
    public GameItem Item { get; set; } = new();
    public double AmountPerSecond { get; set; } = 1.0;
    public RateType RateType { get; set; } = RateType.PerSecond;
    public double MachineCountValue { get; set; } = 1.0;
}

public class TreeConfig
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N")[..8];
    public string Name { get; set; } = "";
    public string ModpackId { get; set; } = "";
    public List<ProductionRequest> Requests { get; set; } = new();
}

public class SavedTreeData
{
    public List<TreeConfig> Trees { get; set; } = new();
}

public class SavedCalculationState
{
    public string ModpackId { get; set; } = "";
    public string TreeId { get; set; } = "";
    public List<SavedRequestItem> Requests { get; set; } = new();
    public Dictionary<string, string>? RecipeChoices { get; set; }
    public Dictionary<string, int>? TierChoices { get; set; }
    public Dictionary<string, int>? CoilChoices { get; set; }
}

public class SavedRequestItem
{
    public string ItemId { get; set; } = "";
    public double AmountPerSecond { get; set; }
    public int RateType { get; set; }
    public double MachineCountValue { get; set; }
}