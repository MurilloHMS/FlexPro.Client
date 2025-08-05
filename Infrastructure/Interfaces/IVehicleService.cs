using FlexPro.Client.Domain.Models;

namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IVehicleService
{
    IReadOnlyList<string> GetVehicleBrands();
    Task<ApiResponse<List<Veiculo>>> GetVehicleAsync();
}