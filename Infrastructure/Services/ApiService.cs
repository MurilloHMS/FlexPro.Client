using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FlexPro.Client.Infrastructure.Interfaces;
using FlexPro.Client.Models;

namespace FlexPro.Client.Services;

public class ApiService<TRequest, TResponse> 
    where TRequest : class 
    where TResponse : class
{
    protected readonly HttpClient _http;
    protected readonly JsonSerializerOptions _options;

    public ApiService(HttpClient http, JsonSerializerOptions options)
    {
        _http = http;
        _options = options;
    }
    
    public async Task<ApiResponse<IEnumerable<TResponse>>> GetAllAsync(string url)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<IEnumerable<TResponse>>(url);
            if (response != null && response.Any())
            {
                return ApiResponse<IEnumerable<TResponse>>.Success(response);
            }
            else
            {
                return ApiResponse<IEnumerable<TResponse>>.Fail("Nenhum dado encontrado.");
            }
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
            var response = await _http.GetFromJsonAsync<TResponse>($"{url}/{id}");
            if (response != null)
            {
                return ApiResponse<TResponse>.Success(response);
            }
            else
            {
                return ApiResponse<TResponse>.Fail("Nenhum dado encontrado.");
            }
        }
        catch (Exception e)
        {
             return ApiResponse<TResponse>.Fail(e.Message);   
        }
    }

    public async Task<ApiResponse<string>> CreateAsync(string url,TRequest? dataRequest)
    {
        try
        {
            if (dataRequest is null)
                return new ApiResponse<string>("Request data is null", HttpStatusCode.BadRequest);
            
            var response = await _http.PostAsJsonAsync(url, dataRequest);
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
            
            var response = await _http.PutAsJsonAsync(url, dataRequest);
            return new ApiResponse<string>(await response.Content.ReadAsStringAsync(), response.StatusCode);
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
            var response = await _http.DeleteAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return ApiResponse<string>.Success(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return ApiResponse<string>.Fail(await response.Content.ReadAsStringAsync());
            }
        }
        catch (HttpRequestException e)
        {
            return ApiResponse<string>.Fail(e.Message);
        }
    }
}