using System.Text.Json;
using FlexPro.Client.Models.Response;

namespace FlexPro.Client.Services;

public class ProdutoService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public ProdutoService(HttpClient http, JsonSerializerOptions options)
    {
        _http = http;
        _options = options;
    }

    public async Task<IEnumerable<ProdutoLojaResponse>> GetProdutoLoja()
    {
        var stream = await _http.GetStreamAsync("api/produto/produtoloja");
        return await JsonSerializer.DeserializeAsync<List<ProdutoLojaResponse>>(stream, _options);
    }

    public async Task<ProdutoLojaResponse> GetByIdAsync(int id)
    {
        var stream = await _http.GetStreamAsync($"api/produto/produtoloja/{id}");
        return await JsonSerializer.DeserializeAsync<ProdutoLojaResponse>(stream, _options);
    }
}