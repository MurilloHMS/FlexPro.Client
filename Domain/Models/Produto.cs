namespace FlexPro.Client.Domain.Models;

public class Produto
{
    public int Id { get; set; }
    public string CodigoSistema { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal QuantidadeFormula { get; set; }
    public decimal QuantidadeProducao { get; set; }
    public string MateriaPrima { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public int IdReceita { get; set; }
    public virtual Receita? Receita { get; set; }
}