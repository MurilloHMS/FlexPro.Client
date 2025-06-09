using System.Net;
using System.Net.Http.Json;
using FlexPro.Client.Models;
using Microsoft.AspNetCore.Components;

namespace FlexPro.Client.Services;

public class AuthService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly LocalStorageService _localStorageService;
    private readonly NavigationManager _navigationManager;

    public AuthService(HttpClient httpClient, IConfiguration configuration, NavigationManager navigationManager,
        LocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
    }

    public async Task<(HttpStatusCode, string)> Login(LoginModel loginModel)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginModel);
        var responseMessage = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            if (result?.Token != null)
            {
                await _localStorageService.SetItemAsync("authToken", result.Token);
                return (HttpStatusCode.OK, result.Token);
            }
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return (HttpStatusCode.NotFound, responseMessage);
        }

        return (HttpStatusCode.BadRequest, responseMessage);
    }

    public async Task<bool> Register(RegisterModel registerModel)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/register", registerModel);
        return response.IsSuccessStatusCode;
    }

    public async Task<string> GetAuthToken()
    {
        return await _localStorageService.GetItemAsync("authToken");
    }

    public async Task Logout()
    {
        await _localStorageService.RemoveItemAsync("authToken");
        _navigationManager.NavigateTo("/Account/Login");
    }
}