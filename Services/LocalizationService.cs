using Microsoft.JSInterop;

namespace TFGCalculator.Services;

public class LocalizationService
{
    private readonly IJSRuntime _js;
    public event Action? OnLanguageChanged;
    private string _lang = "ru";
    public string CurrentLanguage => _lang;

    public LocalizationService(IJSRuntime js) { _js = js; }

    public async Task InitAsync()
    {
        var saved = await _js.InvokeAsync<string?>("lsLoad", "lang");
        if (saved == "en" || saved == "ru") _lang = saved;
    }

    private readonly Dictionary<string, Dictionary<string, string>> _t = new()
    {
        ["ru"] = new()
        {
            ["SelectModpack"]="Выберите модпак",["SearchModpack"]="Поиск модпака...",
            ["SelectItem"]="Выберите предмет",["SearchItem"]="Поиск предмета...",
            ["Calculate"]="Рассчитать",["SupportCreator"]="Поддержать создателя",
            ["BackToModpacks"]="Назад к выбору модпака",["BackToItems"]="Назад к выбору предметов",
            ["NothingFound"]="Ничего не найдено",["AmountPerSec"]="Кол-во/сек:",
            ["Machines"]="Механизмы",["RawResources"]="Базовые ресурсы",
            ["BaseResource"]="Базовый ресурс",["Storage"]="Хранилище",
            ["Level"]="Уровень",["Coil"]="Катушка",["Quantity"]="Кол-во",
            ["Resource"]="Ресурс",["PerSec"]="/сек",
            ["NoMachines"]="Нет механизмов",["NoResources"]="Нет базовых ресурсов",
            ["NoData"]="Нет данных для отображения.",["ReturnHome"]="Вернуться на главную",
            ["SiteTFG"]="Сайт TFG",["GitHubTFG"]="GitHub TFG",["ReportBug"]="Сообщите об ошибке",
            ["GitHubProject"]="GitHub проекта",
            ["SelectRecipe"]="Выбрать рецепт",["ChangeRecipe"]="Изменить рецепт",
            ["Name"]="Название",["Type"]="Тип",["Tag"]="Тег",["Machine"]="Механизм",
            ["CycleDetected"]="Цикл",["TotalEnergy"]="Суммарная энергия",
            ["EnergyPerTick"]="Энергия/тик",["AddItem"]="Добавить предмет",
            ["AddTree"]="Добавить древо",["DeleteTree"]="Удалить",
            ["Rename"]="Переименовать",["TreeName"]="Название древа",
            ["GoToTree"]="Перейти к древу",
            ["RatePerSecond"]="Скорость/сек",["RateMachines"]="Кол-во механизмов",
            ["RateViewOnly"]="Только рецепты",
            ["Amps"]="Ампер",["VoltageLevel"]="Ур. напряжения",
            ["Temperature"]="Температура",["Parallels"]="Параллели",
        },
        ["en"] = new()
        {
            ["SelectModpack"]="Select modpack",["SearchModpack"]="Search modpack...",
            ["SelectItem"]="Select item",["SearchItem"]="Search item...",
            ["Calculate"]="Calculate",["SupportCreator"]="Support creator",
            ["BackToModpacks"]="Back to modpack selection",["BackToItems"]="Back to items",
            ["NothingFound"]="Nothing found",["AmountPerSec"]="Amount/sec:",
            ["Machines"]="Machines",["RawResources"]="Raw resources",
            ["BaseResource"]="Raw resource",["Storage"]="Storage",
            ["Level"]="Level",["Coil"]="Coil",["Quantity"]="Qty",
            ["Resource"]="Resource",["PerSec"]="/sec",
            ["NoMachines"]="No machines",["NoResources"]="No raw resources",
            ["NoData"]="No data to display.",["ReturnHome"]="Return to home",
            ["SiteTFG"]="TFG Website",["GitHubTFG"]="GitHub TFG",["ReportBug"]="Report a bug",
            ["GitHubProject"]="Project GitHub",
            ["SelectRecipe"]="Select recipe",["ChangeRecipe"]="Change recipe",
            ["Name"]="Name",["Type"]="Type",["Tag"]="Tag",["Machine"]="Machine",
            ["CycleDetected"]="Cycle",["TotalEnergy"]="Total energy",
            ["EnergyPerTick"]="Energy/tick",["AddItem"]="Add item",
            ["AddTree"]="Add tree",["DeleteTree"]="Delete",
            ["Rename"]="Rename",["TreeName"]="Tree name",
            ["GoToTree"]="Go to tree",
            ["RatePerSecond"]="Rate/sec",["RateMachines"]="Machine count",
            ["RateViewOnly"]="Recipes only",
            ["Amps"]="Amps",["VoltageLevel"]="Voltage level",
            ["Temperature"]="Temperature",["Parallels"]="Parallels",
        }
    };

    public string Get(string key)
    {
        if (_t.TryGetValue(_lang, out var d) && d.TryGetValue(key, out var v)) return v;
        return key;
    }

    public async Task SetLanguageAsync(string lang)
    {
        if (_lang != lang && _t.ContainsKey(lang))
        {
            _lang = lang;
            await _js.InvokeVoidAsync("lsSave", "lang", lang);
            OnLanguageChanged?.Invoke();
        }
    }

    public async Task ToggleLanguageAsync() => await SetLanguageAsync(_lang == "ru" ? "en" : "ru");
}