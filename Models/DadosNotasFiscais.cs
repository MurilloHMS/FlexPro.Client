
namespace FlexPro.Client.Models;

public class DadosNotasFiscais
{
    public string Fornecedor { get; set; }
    public string NumeroNota { get; set; }
    public DateTime DataNota { get; set; }
    public string Produto { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; } 
    public string CFOP { get; set; }
}