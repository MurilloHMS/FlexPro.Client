using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;

namespace FlexPro.Client.Services;

public class AuthDelegatingHandler : DelegatingHandler
{
    private readonly NavigationManager _navigationManager;

    private readonly LocalStorageService _storageService;

    public AuthDelegatingHandler(LocalStorageService storageService, NavigationManager navigationManager)
    {
        _storageService = storageService;
        _navigationManager = navigationManager;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _storageService.GetItemAsync("authToken");
        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _storageService.RemoveItemAsync("authToken");
            _navigationManager.NavigateTo("Account/login?sessionExpired=true", true);
        }

        return response;
    }
}