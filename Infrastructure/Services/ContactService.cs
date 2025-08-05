using System.Net;
using System.Net.Http.Json;
using FlexPro.Client.Domain.Models;
using FlexPro.Client.Domain.Models.Request;
using FlexPro.Client.Domain.Models.Response;
using FlexPro.Client.Infrastructure.Interfaces;

namespace FlexPro.Client.Infrastructure.Services;

public sealed class ContactService(HttpClient http) : IContactService
{
    public async Task<IEnumerable<ContactResponse>?> GetAllAsync()
    {
        var response = await http.GetAsync("api/contato");
        return response.IsSuccessStatusCode 
            ?  response.Content.ReadFromJsonAsync<List<ContactResponse>>().Result
            : null;
    }

    public async Task<ApiResponse<string>> SaveAsync(ContatoRequest contact)
    {
        try
        {
            var request = await http.PostAsJsonAsync("api/contato", contact);
            request.EnsureSuccessStatusCode();
            
            return request.IsSuccessStatusCode
                ? ApiResponse<string>.Success(request.Content.ReadAsStringAsync().Result)
                : ApiResponse<string>.Fail($"Erro {(int)request.StatusCode}: {request.Content.ReadAsStringAsync().Result}");
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<string>.Fail($"Erro de conexão: {ex.Message}", HttpStatusCode.ServiceUnavailable);
        }
        catch (Exception ex)
        {
            return ApiResponse<string>.Fail($"Erro inesperado: {ex.Message}", HttpStatusCode.InternalServerError);
        }
    }
}