using System.ComponentModel.DataAnnotations;
using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Domain.Models.Request;

public class ContatoRequest
{
    public string Nome { get; set; } = string.Empty;

    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Digite um email válido")]
    public string Email { get; set; } = string.Empty;

    public TipoContatoE TipoContato { get; set; }
    public string? Outro { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public string NomeEmpresa { get; set; } = string.Empty;
    public StatusContatoE StatusContato { get; set; }
    public DateTime DataSolicitadoContato { get; set; }
}