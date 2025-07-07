using FlexPro.Client.Models;

namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IApiService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    Task<ApiResponse<IEnumerable<TResponse>>> GetAllAsync(string url);
    Task<ApiResponse<TResponse>> GetByIdAsync(string url, int id);
    
    Task<ApiResponse<string>> DeleteAsync(string url, int id);
    Task<ApiResponse<string>> UpdateAsync(string url, TRequest? dataRequest);
}