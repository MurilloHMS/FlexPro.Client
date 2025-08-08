using System.Net;
using FlexPro.Client.Application.DTOs;
using FlexPro.Client.Domain.Models;
using FlexPro.Client.Domain.Models.Response;

namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IAuthService
{
    Task<(HttpStatusCode, string)> Login(LoginModel loginModel);
    Task<bool> Register(RegisterModel registerModel);
    Task<string> GetAuthToken();
    Task Logout();
    Task<ApiResponse<List<UserResponse>>> GetAllUsersAsync();
    Task<bool> UpdateUserAsync(RegisterModel registerModel);
    Task<string?> UpdatePassword(UpdatePasswordDto dto);
}