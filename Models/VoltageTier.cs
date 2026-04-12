namespace TFGCalculator.Models;

public class VoltageTier
{
    public int Level { get; set; }
    public string Name { get; set; } = "";
    public string CssClass { get; set; } = "";
    public string Color { get; set; } = "";
    public string IconPath { get; set; } = "";

    public static readonly List<VoltageTier> AllTiers = new()
    {
        new() { Level = 1,  Name = "ULV", CssClass = "tier-ulv", Color = "#555555", IconPath = "images/tiers/ulv.gif" },
        new() { Level = 2,  Name = "LV",  CssClass = "tier-lv",  Color = "#aaaaaa", IconPath = "images/tiers/lv.gif" },
        new() { Level = 3,  Name = "MV",  CssClass = "tier-mv",  Color = "#00aaff", IconPath = "images/tiers/mv.gif" },
        new() { Level = 4,  Name = "HV",  CssClass = "tier-hv",  Color = "#ccaa00", IconPath = "images/tiers/hv.gif" },
        new() { Level = 5,  Name = "EV",  CssClass = "tier-ev",  Color = "#aa00aa", IconPath = "images/tiers/ev.gif" },
        new() { Level = 6,  Name = "IV",  CssClass = "tier-iv",  Color = "#0044cc", IconPath = "images/tiers/iv.gif" },
        new() { Level = 7,  Name = "LuV", CssClass = "tier-luv", Color = "#ff88cc", IconPath = "images/tiers/luv.gif" },
        new() { Level = 8,  Name = "ZPM", CssClass = "tier-zpm", Color = "#ff6666", IconPath = "images/tiers/zpm.gif" },
        new() { Level = 9,  Name = "UV",  CssClass = "tier-uv",  Color = "#00cccc", IconPath = "images/tiers/uv.gif" },
        new() { Level = 10, Name = "UHV", CssClass = "tier-uhv", Color = "#ff0000", IconPath = "images/tiers/uhv.gif" },
    };

    public static VoltageTier GetByLevel(int level) =>
        AllTiers.FirstOrDefault(t => t.Level == level) ?? AllTiers[0];
}