using System.Net;
using System.Net.Http.Json;
using FlexPro.Client.Domain.Models;
using FlexPro.Client.Domain.Models.Request;
using FlexPro.Client.Domain.Models.Response;
using FlexPro.Client.Infrastructure.Interfaces;

namespace FlexPro.Client.Services;

public class ContactService : IContactService
{
    private readonly HttpClient _http;

    public ContactService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<ContactResponse>> GetAllAsync()
    {
        var response = await _http.GetAsync("api/contato");
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<List<ContactResponse>>().Result;
        }
        return Enumerable.Empty<ContactResponse>();
    }

    public async Task<ApiResponse<string>> SaveAsync(ContatoRequest contact)
    {
        try
        {
            var request = await _http.PostAsJsonAsync("api/contato", contact);
            request.EnsureSuccessStatusCode();

            if (request.IsSuccessStatusCode)
            {
                return ApiResponse<string>.Success(request.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return ApiResponse<string>.Fail($"Erro {(int)request.StatusCode}: {request.Content.ReadAsStringAsync().Result}");
            }

        }catch (HttpRequestException ex)
        {
            return ApiResponse<string>.Fail($"Erro de conexão: {ex.Message}", HttpStatusCode.ServiceUnavailable);
        }
        catch (Exception ex)
        {
            return ApiResponse<string>.Fail($"Erro inesperado: {ex.Message}", HttpStatusCode.InternalServerError);
        }
    }
}