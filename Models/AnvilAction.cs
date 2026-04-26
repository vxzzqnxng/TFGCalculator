namespace TFGCalculator.Models;

public enum AnvilActionType
{
    LightHit,   // -3
    Hit,         // -6
    HeavyHit,   // -9
    Draw,        // -15
    Punch,       // +2
    Bend,        // +7
    Upset,       // +13
    Shrink       // +16
}

public static class AnvilActions
{
    public static readonly List<AnvilActionInfo> All = new()
    {
        new() { Type = AnvilActionType.LightHit, NameRu = "Слабо ударить", NameEn = "Light Hit", Value = -3, IconPath = "images/anvil/light_hit.png" },
        new() { Type = AnvilActionType.Hit, NameRu = "Ударить", NameEn = "Hit", Value = -6, IconPath = "images/anvil/hit.png" },
        new() { Type = AnvilActionType.HeavyHit, NameRu = "Сильно ударить", NameEn = "Heavy Hit", Value = -9, IconPath = "images/anvil/heavy_hit.png" },
        new() { Type = AnvilActionType.Draw, NameRu = "Протянуть", NameEn = "Draw", Value = -15, IconPath = "images/anvil/draw.png" },
        new() { Type = AnvilActionType.Punch, NameRu = "Штамповать", NameEn = "Punch", Value = +2, IconPath = "images/anvil/punch.png" },
        new() { Type = AnvilActionType.Bend, NameRu = "Изогнуть", NameEn = "Bend", Value = +7, IconPath = "images/anvil/bend.png" },
        new() { Type = AnvilActionType.Upset, NameRu = "Обжать", NameEn = "Upset", Value = +13, IconPath = "images/anvil/upset.png" },
        new() { Type = AnvilActionType.Shrink, NameRu = "Усадить", NameEn = "Shrink", Value = +16, IconPath = "images/anvil/shrink.png" },
    };

    public static AnvilActionInfo Get(AnvilActionType t) => All.First(a => a.Type == t);
    public static bool IsAnyHit(AnvilActionType t) => t is AnvilActionType.LightHit or AnvilActionType.Hit or AnvilActionType.HeavyHit;
}

public class AnvilActionInfo
{
    public AnvilActionType Type { get; set; }
    public string NameRu { get; set; } = "";
    public string NameEn { get; set; } = "";
    public int Value { get; set; }
    public string IconPath { get; set; } = "";
    public string GetName(string lang) => lang == "en" ? NameEn : NameRu;
}