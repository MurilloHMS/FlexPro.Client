using FlexPro.Client.Models;

namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IVehicleService
{
    string[] GetVehicleBrands();
    Task<ApiResponse<List<Veiculo>>> GetVehicleAsync();
}