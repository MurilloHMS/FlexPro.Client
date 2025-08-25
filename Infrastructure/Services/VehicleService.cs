using System.Net;
using System.Net.Http.Json;
using FlexPro.Client.Domain.Models;
using FlexPro.Client.Infrastructure.Interfaces;

namespace FlexPro.Client.Infrastructure.Services;

public class VehicleService(HttpClient http, ILogger<VehicleService> logger) : IVehicleService
{

    private static readonly string[] VehicleBrands =
    [
        "ACURA", "ALFA ROMEO", "AUDI", "BMW", "BUICK", "CADILLAC", "CHEVROLET", "CHERY", "CITROËN", "DODGE", "FERRARI",
        "FIAT", "FORD", "GMC", "HONDA",
        "HYUNDAI", "INFINITI", "JAGUAR", "JEEP", "KIA", "LAMBORGHINI", "LAND ROVER", "LEXUS", "LINCOLN", "MITSUBISHI",
        "MERCEDES-BENZ",
        "MINI", "MITSUBISHI", "NISSAN", "PEUGEOT", "PORSCHE", "RAM", "RENAULT", "SANTA FÉ", "SEAT", "SUBARU", "SUZUKI",
        "TESLA", "TOYOTA", "VOLKSWAGEN",
        "VOLVO", "ZAZ", "TROLLER", "JAC MOTORS", "FOTON", "GREAT WALL", "TATA", "BYD", "DIESEL", "MERCURY", "SPYKER",
        "SMART", "DAEWOO", "FIAT CHRYSLER",
        "HONDA", "LIFAN", "CHERY", "CROSSFOX", "RENAULT", "FORD"
    ];

    public IReadOnlyList<string> GetVehicleBrands() => VehicleBrands;

    public async Task<ApiResponse<List<Veiculo>>> GetVehicleAsync()
    {
        try
        {
            var response = await http.GetAsync("api/vehicle");

            var statusCode = response.StatusCode;
            var rawMessage = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<Veiculo>>();
                return ApiResponse<List<Veiculo>>.Success(data, "Veículos obtidos com sucesso.");
            }

            return ApiResponse<List<Veiculo>>.Fail($"Erro {statusCode}: {rawMessage}", statusCode);
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<List<Veiculo>>.Fail($"Erro de conexão: {ex.Message}", HttpStatusCode.ServiceUnavailable);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<Veiculo>>.Fail($"Erro inesperado: {ex.Message}",
                HttpStatusCode.InternalServerError);
        }
    }

    public async Task<HttpStatusCode> DeleteVehicle(int id)
    {
        try
        {
           var response = await http.DeleteAsync($"api/vehicle/{id}");
           if (response.IsSuccessStatusCode)
               return HttpStatusCode.OK;
           
           return HttpStatusCode.InternalServerError;
        }
        catch (HttpRequestException e)
        {
            logger.LogError($"Ocorreu um erro ao deletar o veiculo: {e.Message}");
            throw;
        }
        catch (Exception e)
        {
            logger.LogError($"Ocorreu um erro desconhecido ao deletar o veiculo: {e.Message}");
            throw;
        }
    }

    public async Task<HttpStatusCode> UpdateAsync(Veiculo veiculo)
    {
        try
        {
            var response = await http.PutAsJsonAsync($"api/vehicle/{veiculo.Id}", veiculo);
            if (response.IsSuccessStatusCode)
                return HttpStatusCode.OK;
           
            return HttpStatusCode.InternalServerError;
        }
        catch (HttpRequestException e)
        {
            logger.LogError($"Ocorreu um erro ao atualizar o veiculo: {e.Message}");
            throw;
        }
        catch (Exception e)
        {
            logger.LogError($"Ocorreu um erro desconhecido ao atualizar o veiculo: {e.Message}");
            throw;
        }
    }
    
    public async Task<HttpStatusCode> CreateAsync(Veiculo veiculo)
    {
        try
        {
            var response = await http.PostAsJsonAsync($"api/vehicle", veiculo);
            if (response.IsSuccessStatusCode)
                return HttpStatusCode.OK;
           
            return HttpStatusCode.InternalServerError;
        }
        catch (HttpRequestException e)
        {
            logger.LogError($"Ocorreu um erro ao salvar o veiculo: {e.Message}");
            throw;
        }
        catch (Exception e)
        {
            logger.LogError($"Ocorreu um erro desconhecido ao salvar o veiculo: {e.Message}");
            throw;
        }
    }
}