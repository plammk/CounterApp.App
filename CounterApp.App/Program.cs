using CounterApp.App;
using CounterApp.App.Components.Games;
using CounterApp.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IGameDataService, GameDataService>(client => client.BaseAddress = new Uri("https://localhost:7176"));
builder.Services.AddHttpClient<IPlayerDataService, PlayerDataService>(client => client.BaseAddress = new Uri("https://localhost:7176"));
await builder.Build().RunAsync();
