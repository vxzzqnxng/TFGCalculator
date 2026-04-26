namespace TFGCalculator.Models;

public class ArrowItemInfo
{
    public string ItemId { get; set; } = "";
    public string IconUrl { get; set; } = "";
    public string ItemName { get; set; } = "";
}

public class ArrowConnection
{
    public string FromNode { get; set; } = "";
    public string ToNode { get; set; } = "";
    public string FromSide { get; set; } = "top";
    public string ToSide { get; set; } = "bottom";
    public int FromIndex { get; set; }
    public int FromTotal { get; set; } = 1;
    public int ToIndex { get; set; }
    public int ToTotal { get; set; } = 1;
    public List<ArrowItemInfo> Items { get; set; } = new();
}