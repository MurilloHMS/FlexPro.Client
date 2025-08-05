using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FlexPro.Client.Domain.Models;

namespace FlexPro.Client.Infrastructure.Services;

public class ApiService<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    protected readonly HttpClient Http;
    protected readonly JsonSerializerOptions JsonOptions;

    public ApiService(HttpClient http, JsonSerializerOptions jsonOptions)
    {
        this.Http = http;
        this.JsonOptions = jsonOptions;
    }

    public async Task<ApiResponse<IEnumerable<TResponse>>> GetAllAsync(string url)
    {
        try
        {
            var response = await Http.GetFromJsonAsync<IEnumerable<TResponse>>(url);
            return response != null
                ? ApiResponse<IEnumerable<TResponse>>.Success(response)
                : ApiResponse<IEnumerable<TResponse>>.Fail("Nenhum dado encontrado.");
        }
        catch (Exception e)
        {
            return ApiResponse<IEnumerable<TResponse>>.Fail(e.Message);
        }
    }

    public async Task<ApiResponse<TResponse>> GetByIdAsync(string url, int id)
    {
        try
        {
            var response = await Http.GetFromJsonAsync<TResponse>($"{url}/{id}");
            return response != null    
                ? ApiResponse<TResponse>.Success(response)
                : ApiResponse<TResponse>.Fail("Nenhum dado encontrado.");
        }
        catch (Exception e)
        {
            return ApiResponse<TResponse>.Fail(e.Message);
        }
    }

    public async Task<ApiResponse<string>> CreateAsync(string url, TRequest? dataRequest)
    {
        try
        {
            if (dataRequest is null)
                return new ApiResponse<string>("Request data is null", HttpStatusCode.BadRequest);

            var response = await Http.PostAsJsonAsync(url, dataRequest);
            return ApiResponse<string>.Success(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            return ApiResponse<string>.Fail(e.Message);
        }
    }

    public async Task<ApiResponse<string>> UpdateAsync(string url, TResponse? dataRequest)
    {
        try
        {
            if (dataRequest is null)
                return new ApiResponse<string>("Request data is null", HttpStatusCode.BadRequest);

            var response = await Http.PutAsJsonAsync(url, dataRequest);
            return response.IsSuccessStatusCode
                ? ApiResponse<string>.Success(await response.Content.ReadAsStringAsync())
                : ApiResponse<string>.Fail(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            return new ApiResponse<string>(e.Message, HttpStatusCode.BadRequest);
        }
    }

    public async Task<ApiResponse<string>> DeleteAsync(string url, int id)
    {
        try
        {
            var response = await Http.DeleteAsync($"{url}/{id}");
            return response.IsSuccessStatusCode
                ? ApiResponse<string>.Success(await response.Content.ReadAsStringAsync())
                : ApiResponse<string>.Fail(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            return ApiResponse<string>.Fail(e.Message);
        }
    }
}