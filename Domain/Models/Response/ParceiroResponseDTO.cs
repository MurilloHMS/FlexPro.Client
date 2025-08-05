namespace FlexPro.Client.Domain.Models.Response;

public class ParceiroResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? CodigoSistema { get; set; }
    public string? Email { get; set; }
    public bool Ativo { get; set; }
    public string? RazaoSocial { get; set; }
    public bool RecebeEmail { get; set; }
}