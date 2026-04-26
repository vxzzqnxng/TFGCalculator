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
        else if (Type == "Пыль") return $"images/tfg-modern/items/dusts/{Id}.png";
        else if (Type == "Слиток") return $"images/tfg-modern/items/ingots/{Id}.png";
        else if (Type == "Горячий слиток") return $"images/tfg-modern/items/hot_ingots/{Id}.png";
        else if (Type == "Стержень") return $"images/tfg-modern/items/rods/{Id}.png";
        else if (Type == "Жидкость") return $"images/tfg-modern/items/fluids/{Id}.png";
        else if (Type == "Очищенная руда") return $"images/tfg-modern/items/purified_ores/{Id}.png";
        else if (Type == "Двойной слиток") return $"images/tfg-modern/items/double_ingots/{Id}.png";
        else if (Type == "Пластина") return $"images/tfg-modern/items/plates/{Id}.png";
        else if (Type == "Двойная пластина") return $"images/tfg-modern/items/double_plates/{Id}.png";
        else if (Type == "Болт") return $"images/tfg-modern/items/bolts/{Id}.png";
        else if (Type == "Винт") return $"images/tfg-modern/items/screws/{Id}.png";
        else if (Type == "Оголовье") return $"images/tfg-modern/items/tool_heads/{Id}.png";
        else if (Type == "Самородок") return $"images/tfg-modern/items/nuggets/{Id}.png";
        else if (Type == "Кольцо") return $"images/tfg-modern/items/rings/{Id}.png";
        else if (Type == "Шестерня") return $"images/tfg-modern/items/gears/{Id}.png";
        else if (Type == "Маленькая шестерня") return $"images/tfg-modern/items/small_gears/{Id}.png";
        else if (Type == "Пружина") return $"images/tfg-modern/items/springs/{Id}.png";
        else if (Type == "Маленькая пружина") return $"images/tfg-modern/items/small_springs/{Id}.png";
        else if (Type == "Прут") return $"images/tfg-modern/items/long_rods/{Id}.png";
        else return $"images/tfg-modern/items/{Id}.png";
    }
}