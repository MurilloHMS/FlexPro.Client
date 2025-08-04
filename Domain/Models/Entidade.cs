namespace FlexPro.Client.Domain.Models;

public class Entidade
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? CodigoSistema { get; set; }
    public string? Email { get; set; }
    public bool Ativo { get; set; } = true;
}