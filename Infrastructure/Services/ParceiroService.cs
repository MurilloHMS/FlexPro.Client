using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FlexPro.Client.Infrastructure.Interfaces;
using FlexPro.Client.Models;
using FlexPro.Client.Models.Request;
using FlexPro.Client.Models.Response;

namespace FlexPro.Client.Services;

public class ParceiroService : ApiService<ParceiroRequestDTO, ParceiroResponseDTO>
{

    public ParceiroService(HttpClient http, JsonSerializerOptions options) : base(http, options) { }

    public async Task<ApiResponse<ParceiroResponseDTO>> CreateAsync(ParceiroRequestDTO parceiroRequest)
    {
        if (parceiroRequest is null)
            return new ApiResponse<ParceiroResponseDTO>("Parceiro request is null", HttpStatusCode.NotFound);

        var response = await _http.PostAsJsonAsync("api/parceiro", parceiroRequest);
        return new ApiResponse<ParceiroResponseDTO>(await response.Content.ReadAsStringAsync(), response.StatusCode);
    }

    public async Task<ApiResponse<string>> UploadAsync(string url, MultipartFormDataContent content)
    {
        try
        {
            var response = await _http.PostAsync(url, content);
            return ApiResponse<string>.Success(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            return ApiResponse<string>.Fail(e.Message);
        }
        
    }
}