﻿namespace FlexPro.Client.Domain.Models;

public class Veiculo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public double? ConsumoUrbanoAlcool { get; set; }
    public double? ConsumoRodoviarioAlcool { get; set; }
    public double? ConsumoUrbanoGasolina { get; set; }
    public double? ConsumoRodoviarioGasolina { get; set; }
}