using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Models.Request;

public class ClienteRequest
{
    public string CodigoSistema { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public StatusContato_e Status { get; set; }
    public string Contato { get; set; }
    public FormasDeContato_e MeioDeContato { get; set; }
}