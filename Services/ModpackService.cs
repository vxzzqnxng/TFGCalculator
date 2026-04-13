namespace TFGCalculator.Services;

using TFGCalculator.Models;

public class ModpackService
{
    private readonly List<Modpack> _modpacks = new()
    {
        new Modpack { Id = "tfg-0.12.3", Name = "TerraFirmaGreg-Modern ver0.12.3" },
        // Добавьте новые модпаки здесь:
        // new Modpack { Id = "", Name = "" },
    };

    public List<Modpack> GetAll() => _modpacks;

    public Modpack? GetById(string id) => _modpacks.FirstOrDefault(m => m.Id == id);

    public List<Modpack> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return _modpacks;

        return _modpacks
            .Where(m => m.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}