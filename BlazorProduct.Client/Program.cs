using BlazorProduct.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorProduct.Client.HttpResponsitori;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7266/api/") });
builder.Services.AddScoped<IProductHttpResponsitori, ProductHttpResponsitori>();
await builder.Build().RunAsync();
