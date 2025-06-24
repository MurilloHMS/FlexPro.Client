namespace FlexPro.Client.Models.Response;

public class ProdutoLojaResponse
{
    public int Id { get; set; }
    public string CodigoSistema { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Cor { get; set; }
    public string Diluicao { get; set; }
    public byte[] Imagem { get; set; }
    public IEnumerable<Embalagem> Embalagems { get; set; }
    public IEnumerable<Departamento> Departamentos { get; set; }
}