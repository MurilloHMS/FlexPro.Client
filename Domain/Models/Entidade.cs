namespace FlexPro.Client.Domain.Models;

public class Entidade
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string? CodigoSistema { get; set; }
    public string? Email { get; set; }
    public bool Ativo { get; set; } =  true;
}