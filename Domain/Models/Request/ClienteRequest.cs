using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Domain.Models.Request;

public class ClienteRequest
{
    public string CodigoSistema { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public StatusContato_e Status { get; set; }
    public string Contato { get; set; } = string.Empty;
    public FormasDeContato_e MeioDeContato { get; set; }
}