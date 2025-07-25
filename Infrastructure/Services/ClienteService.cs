using System.Text.Json;
using FlexPro.Client.Models.Response;

namespace FlexPro.Client.Services;

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
        return await JsonSerializer.DeserializeAsync<List<ClienteResponse>>(stream, _options);
    }
}