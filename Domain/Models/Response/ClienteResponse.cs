using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Domain.Models.Response;

public class ClienteResponse
{
    public int Id { get; set; }
    public string CodigoSistema { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public StatusContato_e Status { get; set; }
    public string Contato { get; set; }
    public FormasDeContato_e MeioDeContato { get; set; }
}