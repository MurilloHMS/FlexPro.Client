using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Domain.Models.Response;

public class ContactResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public TipoContatoE TipoContato { get; set; }
    public string? Outro { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public string NomeEmpresa { get; set; } = string.Empty;
    public StatusContatoE StatusContato { get; set; }
    public DateTime DataSolicitadoContato { get; set; }
}