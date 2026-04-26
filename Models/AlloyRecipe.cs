namespace TFGCalculator.Models;

public class AlloyComponent
{
    public string MetalItemId { get; set; } = "";
    public double MinPercent { get; set; }
    public double MaxPercent { get; set; }
}

public class AlloyRecipe
{
    public string Id { get; set; } = "";
    public string ResultItemId { get; set; } = "";
    public string NameRu { get; set; } = "";
    public string NameEn { get; set; } = "";
    public List<AlloyComponent> Components { get; set; } = new();
    public string GetName(string lang) => lang == "en" ? NameEn : NameRu;
}