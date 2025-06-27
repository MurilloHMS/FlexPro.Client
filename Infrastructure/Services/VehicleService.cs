
using System.Net;
using System.Net.Http.Json;
using FlexPro.Client.Infrastructure.Interfaces;
using FlexPro.Client.Models;
using MudBlazor;

namespace FlexPro.Client.Services;

public class VehicleService : IVehicleService
{
    private readonly HttpClient _client;

    public VehicleService(HttpClient client)
    {
        _client = client;
    }

    public string[] GetVehicleBrands()
    {
        string[] marcas =
        {
            "ACURA", "ALFA ROMEO", "AUDI", "BMW", "BUICK", "CADILLAC", "CHEVROLET",
            "CHERY", "CITROËN", "DODGE", "FERRARI", "FIAT", "FORD", "GMC", "HONDA",
            "HYUNDAI", "INFINITI", "JAGUAR", "JEEP", "KIA", "LAMBORGHINI",
            "LAND ROVER", "LEXUS", "LINCOLN", "MITSUBISHI", "MERCEDES-BENZ",
            "MINI", "MITSUBISHI", "NISSAN", "PEUGEOT", "PORSCHE", "RAM", "RENAULT",
            "SANTA FÉ", "SEAT", "SUBARU", "SUZUKI", "TESLA", "TOYOTA", "VOLKSWAGEN",
            "VOLVO", "ZAZ", "TROLLER", "JAC MOTORS", "FOTON", "GREAT WALL", "TATA",
            "BYD", "DIESEL", "MERCURY", "SPYKER", "SMART", "DAEWOO", "FIAT CHRYSLER",
            "HONDA", "LIFAN", "CHERY", "CROSSFOX", "RENAULT", "FORD"
        };

        return marcas;
    }

    public async Task<ApiResponse<List<Veiculo>>> GetVehicleAsync()
    {
        try
        {
            var response = await _client.GetAsync($"api/veiculo");

            var statusCode = response.StatusCode;
            var rawMessage = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<Veiculo>>();
                return ApiResponse<List<Veiculo>>.Success(data, "Veículos obtidos com sucesso.");
            }
            else
            {
                return ApiResponse<List<Veiculo>>.Fail($"Erro {statusCode}: {rawMessage}", statusCode);
            }
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<List<Veiculo>>.Fail($"Erro de conexão: {ex.Message}", HttpStatusCode.ServiceUnavailable);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<Veiculo>>.Fail($"Erro inesperado: {ex.Message}", HttpStatusCode.InternalServerError);
        }
    }
}