using System.Net;
using System.Net.Http.Json;
using FlexPro.Client.Application.DTOs;
using FlexPro.Client.Domain.Models;
using FlexPro.Client.Domain.Models.Response;
using FlexPro.Client.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexPro.Client.Infrastructure.Services;

public class AuthService : IAuthService
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

    public async Task<ApiResponse<List<UserResponse>>> GetAllUsersAsync()
    {
        var response = await _httpClient.GetAsync("api/auth/get-all-users");
        var rawMessage = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<List<UserResponse>>();
            return ApiResponse<List<UserResponse>>.Success(data!, "Usuários obtidos com sucesso");
        }
        return ApiResponse<List<UserResponse>>.Fail($"Erro {response.StatusCode}: {rawMessage}");
    }

    public async Task<bool> UpdateUserAsync(UpdateUserModel registerModel)
    {
        var response = await _httpClient.PutAsJsonAsync("api/auth/update", registerModel);
        return response.IsSuccessStatusCode;
    }

    public async Task<string?> UpdatePassword(UpdatePasswordDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync("api/auth/update-password", dto);
        return await response.Content.ReadAsStringAsync();
    }
}