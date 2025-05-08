using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FlexPro.Client;
using MudBlazor.Services;
using FlexPro.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using FlexPro.Client.Providers;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var environment = builder.HostEnvironment;
string databaseUrl = environment.IsDevelopment() ? "http://localhost:5233/" : "https://flexpro-api.onrender.com/";
builder.Services.AddHttpClient("FlexProAPI", client =>
    {
        client.BaseAddress = new Uri(databaseUrl);
    }).AddHttpMessageHandler<AuthDelegatingHandler>();

// Registros de Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FlexProAPI"));

//mudblazor
builder.Services.AddMudServices();

// autenticacao
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthorizationService, DefaultAuthorizationService>();
builder.Services.AddScoped<AuthDelegatingHandler>();

await builder.Build().RunAsync();
