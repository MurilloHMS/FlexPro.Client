using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FlexPro.Client.Models;
using FlexPro.Client.Models.Request;
using FlexPro.Client.Models.Response;

namespace FlexPro.Client.Services;

public class ParceiroService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public ParceiroService(HttpClient http, JsonSerializerOptions options)
    {
        _http = http;
        _options = options;
    }

    public async Task<IEnumerable<ParceiroResponseDTO>> GetAllAsync()
    {
        var ret = await _http.GetFromJsonAsync<IEnumerable<ParceiroResponseDTO>>("api/parceiro");
        return ret;
    }

    public async Task<ParceiroResponseDTO> GetByIdAsync(int id)
    {
        var ret = await _http.GetFromJsonAsync<ParceiroResponseDTO>($"api/parceiro/{id}");
        return ret ?? new ParceiroResponseDTO();
    }

    public async Task<ApiResponse<ParceiroResponseDTO>> CreateAsync(ParceiroRequestDTO parceiroRequest)
    {
        if (parceiroRequest is null)
            return new ApiResponse<ParceiroResponseDTO>("Parceiro request is null", HttpStatusCode.NotFound);

        var response = await _http.PostAsJsonAsync("api/parceiro", parceiroRequest);
        return new ApiResponse<ParceiroResponseDTO>(await response.Content.ReadAsStringAsync(), response.StatusCode);
    }

    public async Task<ApiResponse<string>> UploadParceiros(MultipartFormDataContent content)
    {
        try
        {
            var response = await _http.PostAsync("api/parceiro/upload", content);
            return new ApiResponse<string>(await response.Content.ReadAsStringAsync(), response.StatusCode);
        }
        catch (HttpRequestException e)
        {
            return new ApiResponse<string>(e.Message, HttpStatusCode.BadRequest);
        }
        
    }
}