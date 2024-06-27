using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using HighlightBlazor;
using MudBlazor.Services;
using MudBlocks.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Register HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Register MudBlazor services
builder.Services.AddMudServices(config => {
    config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Filled;
});
// Register HighlightBlazor services
builder.Services.AddHighlight();


await builder.Build().RunAsync();
