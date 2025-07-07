using FlexPro.Client.Models;

namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IApiService<T> where T : class
{
    Task<ApiResponse<T>> Upload(string url, T? dataRequest);
    Task<ApiResponse<IEnumerable<T>>> GetAllAsync(string url);
    Task<ApiResponse<T>> GetByIdAsync(string url, int id);
    
    Task<ApiResponse<string>> DeleteAsync(string url, int id);
    Task<ApiResponse<string>> UpdateAsync(string url, T? dataRequest);
}