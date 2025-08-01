namespace FlexPro.Client.Domain.Models.Response;

public class ProdutoLojaResponse
{
    public int Id { get; set; }
    public string CodigoSistema { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public string Diluicao { get; set; } = string.Empty;
    public byte[]? Imagem { get; set; }
    public IEnumerable<Embalagem>? Embalagems { get; set; }
    public IEnumerable<Departamento>? Departamentos { get; set; }
}