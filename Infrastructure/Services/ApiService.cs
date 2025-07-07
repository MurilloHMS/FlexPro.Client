using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FlexPro.Client.Infrastructure.Interfaces;
using FlexPro.Client.Models;

namespace FlexPro.Client.Services;

public abstract class ApiService<T> : IApiService<T> where T : class
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public ApiService(HttpClient http, JsonSerializerOptions options)
    {
        _http = http;
        _options = options;
    }

    public abstract Task<ApiResponse<T>> Upload(string url, T? dataRequest);
    
    public async Task<ApiResponse<IEnumerable<T>>> GetAllAsync(string url)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<IEnumerable<T>>(url);
            if (response != null && response.Any())
            {
                return ApiResponse<IEnumerable<T>>.Success(response);
            }
            else
            {
                return ApiResponse<IEnumerable<T>>.Fail("Nenhum dado encontrado.");
            }
        }
        catch (Exception e)
        {
            return ApiResponse<IEnumerable<T>>.Fail(e.Message);
        }
    }

    public async Task<ApiResponse<T>> GetByIdAsync(string url, int id)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<T>($"{url}/{id}");
            if (response != null)
            {
                return ApiResponse<T>.Success(response);
            }
            else
            {
                return ApiResponse<T>.Fail("Nenhum dado encontrado.");
            }
        }
        catch (Exception e)
        {
             return ApiResponse<T>.Fail(e.Message);   
        }
    }

    public async Task<ApiResponse<string>> CreateAsync(string url,T? dataRequest)
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

    public async Task<ApiResponse<string>> UpdateAsync(string url, T? dataRequest)
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