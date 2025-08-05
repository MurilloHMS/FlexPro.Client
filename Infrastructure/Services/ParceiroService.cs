using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FlexPro.Client.Domain.Models;
using FlexPro.Client.Domain.Models.Request;
using FlexPro.Client.Domain.Models.Response;

namespace FlexPro.Client.Infrastructure.Services;

public class ParceiroService : ApiService<ParceiroRequestDto, ParceiroResponseDto>
{
    public ParceiroService(HttpClient Http, JsonSerializerOptions options) : base(Http, options)
    {
    }

    public async Task<ApiResponse<ParceiroResponseDto>> CreateAsync(ParceiroRequestDto? parceiroRequest)
    {
        if (parceiroRequest is null)
            return new ApiResponse<ParceiroResponseDto>("Parceiro request is null", HttpStatusCode.NotFound);

        var response = await Http.PostAsJsonAsync("api/parceiro", parceiroRequest);
        return new ApiResponse<ParceiroResponseDto>(await response.Content.ReadAsStringAsync(), response.StatusCode);
    }

    public async Task<ApiResponse<string>> UploadAsync(string url, MultipartFormDataContent content)
    {
        try
        {
            var response = await Http.PostAsync(url, content);
            return ApiResponse<string>.Success(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            return ApiResponse<string>.Fail(e.Message);
        }
    }
}