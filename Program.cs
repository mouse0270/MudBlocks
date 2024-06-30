using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlocks;
using MudBlocks.Services;
using MudBlazor.Services;
using HighlightBlazor;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorPro.BlazorSize;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddMediaQueryService();
builder.Services.AddSingleton<ThemeService>();
builder.Services.AddSingleton<BlockService>();
builder.Services.AddMudServices();
builder.Services.AddHighlight();

await builder.Build().RunAsync();
