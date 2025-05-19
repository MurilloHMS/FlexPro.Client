using System.ComponentModel.DataAnnotations;
using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Models.Request;

public class ContatoRequest
{
    public string Nome { get; set; }
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Digite um email válido")]
    public string Email { get; set; }
    public TipoContato_e TipoContato { get; set; }
    public string? outro { get; set; }
    public string Mensagem { get; set; }
    public string NomeEmpresa { get; set; }
    public StatusContato_e StatusContato { get; set; }
}