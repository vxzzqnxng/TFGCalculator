using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TFGCalculator;
using TFGCalculator.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ModpackService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<RecipeService>();
builder.Services.AddScoped<LocalizationService>();
builder.Services.AddScoped<ThemeService>();
builder.Services.AddScoped<CalculationService>();
builder.Services.AddScoped<StorageService>();
builder.Services.AddScoped<AnvilService>();
builder.Services.AddScoped<AlloyService>();

await builder.Build().RunAsync();