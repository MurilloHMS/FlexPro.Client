using System.Net;
using FlexPro.Client.Domain.Models;

namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IVehicleService
{
    IReadOnlyList<string> GetVehicleBrands();
    Task<ApiResponse<List<Veiculo>>> GetVehicleAsync();
    Task<HttpStatusCode> DeleteVehicle(int id);
    Task<HttpStatusCode> UpdateAsync(Veiculo veiculo);
    Task<HttpStatusCode> CreateAsync(Veiculo veiculo);
}