using System.Security.Claims;
using System.Text.Json;
using FlexPro.Client.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;

namespace FlexPro.Client.Infrastructure.Providers;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthService _authService;

    public ApiAuthenticationStateProvider(AuthService authService)
    {
        _authService = authService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _authService.GetAuthToken();

        var identity = new ClaimsIdentity();
        if (!string.IsNullOrEmpty(token))
            try
            {
                var claims = ParseClaimsFromJwt(token);
                identity = new ClaimsIdentity(claims, "jwt");
            }
            catch
            {
                identity = new ClaimsIdentity();
            }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);
        return state;
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = WebEncoders.Base64UrlDecode(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        var claims = new List<Claim>();

        if (keyValuePairs is null)
            return claims;

        foreach (var kvp in keyValuePairs)
        {
            if (kvp.Key == "role")
            {
                if (kvp.Value is JsonElement { ValueKind: JsonValueKind.Array } roleArray)
                {
                    foreach (var role in roleArray.EnumerateArray())
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.GetString()!));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, kvp.Value.ToString()!));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, kvp.Value.ToString()!));
            }
        }
        return claims;
    }

    public void MarkUserAsAuthenticated(string token)
    {
        var claims = ParseClaimsFromJwt(token);
        var identity = new ClaimsIdentity(claims, "jwt");
        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);
        NotifyAuthenticationStateChanged(Task.FromResult(state));
    }

    public void MarkUserAsLoggedOut()
    {
        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        var state = new AuthenticationState(anonymous);
        NotifyAuthenticationStateChanged(Task.FromResult(state));
    }
}