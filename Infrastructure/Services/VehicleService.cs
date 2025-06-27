
using FlexPro.Client.Infrastructure.Interfaces;

namespace FlexPro.Client.Services;

public class VehicleService : IVehicleService
{
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
}