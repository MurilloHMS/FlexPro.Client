using System.Text.Json;
using System.Text.Json.Serialization;
using FlexPro.Client;
using FlexPro.Client.Infrastructure.Interfaces;
using FlexPro.Client.Providers;
using FlexPro.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var environment = builder.HostEnvironment;
// TODO: update this to environment variables
var databaseUrl = environment.IsDevelopment() ? "http://localhost:5233/" : "https://api.proautokimium.com";
builder.Services.AddHttpClient("FlexProAPI", client => { client.BaseAddress = new Uri(databaseUrl); })
    .AddHttpMessageHandler<AuthDelegatingHandler>();

// Services registry
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FlexProAPI"));
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ParceiroService>();
builder.Services.AddScoped<DeviceDetector>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IContactService, ContactService>();

// Mudblazor
builder.Services.AddMudServices();

// Authentication
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthorizationService, DefaultAuthorizationService>();
builder.Services.AddScoped<AuthDelegatingHandler>();

//jsonSerialize
var jsonOptions = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
};

builder.Services.AddSingleton(jsonOptions);

await builder.Build().RunAsync();