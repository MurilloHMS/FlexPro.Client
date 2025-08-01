using System.Text.Json;
using FlexPro.Client.Domain.Models.Response;

namespace FlexPro.Client.Infrastructure.Services;

public class ClienteService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public ClienteService(HttpClient http, JsonSerializerOptions options)
    {
        _http = http;
        _options = options;
    }

    public async Task<List<ClienteResponse>> GetClientes()
    {
        var stream = await _http.GetStreamAsync("api/cliente");
        return await JsonSerializer.DeserializeAsync<List<ClienteResponse>>(stream, _options) ?? new List<ClienteResponse>();
    }
}