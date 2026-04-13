namespace TFGCalculator.Models;

public class GameItem
{
    public string Id { get; set; } = "";
    public string NameRu { get; set; } = "";
    public string NameEn { get; set; } = "";
    public string Type { get; set; } = "";
    public string Tag { get; set; } = "";
    public string IconPath { get; set; } = "";

    public string GetName(string lang) => lang == "en" ? NameEn : NameRu;
    /// <summary>
    /// Возвращает путь к иконке предмета.
    /// Если IconPath задан — используется он, иначе — генерируется из Id.
    /// </summary>
    public string GetIconUrl()
    {
        if (!string.IsNullOrEmpty(IconPath))
            return IconPath;
        else if (Type == "Пыль") return $"images/items/dusts/{Id}.png";
        else if (Type == "Слиток") return $"images/items/ingots/{Id}.png";
        else if (Type == "Горячий слиток") return $"images/items/hot_ingots/{Id}.png";
        else if (Type == "Стержень") return $"images/items/rods/{Id}.png";
        else if (Type == "Жидкость") return $"images/items/fluids/{Id}.png";
        else if (Type == "Очищенная руда") return $"images/items/purified_ores/{Id}.png";
        else return $"images/items/{Id}.png";
    }
}