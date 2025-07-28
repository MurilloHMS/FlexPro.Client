namespace FlexPro.Client.Domain.Models.Response;

public class ParceiroResponseDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? CodigoSistema { get; set; }
    public string? Email { get; set; }
    public bool Ativo { get; set; }
    public string? RazaoSocial { get; set; }
    public bool RecebeEmail { get; set; }
}