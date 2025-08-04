﻿namespace FlexPro.Client.Domain.Models;

public class InformativoOs
{
    public int NumOs { get; set; }
    public string CodigoCliente { get; set; } =  string.Empty;
    public DateTime DataDeAbertura { get; set; }
    public DateTime DataDeFechamento { get; set; }
    public int DiasDaSemana { get; set; }
}