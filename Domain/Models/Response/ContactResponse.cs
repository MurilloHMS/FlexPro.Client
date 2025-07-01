using System.ComponentModel.DataAnnotations;
using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Models.Response;

public class ContactResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public TipoContato_e TipoContato { get; set; }
    public string? outro { get; set; }
    public string Mensagem { get; set; }
    public string NomeEmpresa { get; set; }
    public StatusContato_e StatusContato { get; set; }
    public DateTime DataSolicitadoContato { get; set; }
}