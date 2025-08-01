using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FlexPro.Client.Domain.Models;
using FlexPro.Client.Domain.Models.Request;
using FlexPro.Client.Domain.Models.Response;

namespace FlexPro.Client.Infrastructure.Services;

public class ParceiroService : ApiService<ParceiroRequestDTO, ParceiroResponseDto>
{
    public ParceiroService(HttpClient http, JsonSerializerOptions options) : base(http, options)
    {
    }

    public async Task<ApiResponse<ParceiroResponseDto>> CreateAsync(ParceiroRequestDTO parceiroRequest)
    {
        if (parceiroRequest is null)
            return new ApiResponse<ParceiroResponseDto>("Parceiro request is null", HttpStatusCode.NotFound);

        var response = await _http.PostAsJsonAsync("api/parceiro", parceiroRequest);
        return new ApiResponse<ParceiroResponseDto>(await response.Content.ReadAsStringAsync(), response.StatusCode);
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