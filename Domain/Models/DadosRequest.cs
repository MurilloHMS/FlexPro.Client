namespace FlexPro.Client.Domain.Models;

public class DadosRequest
{
    public string Month { get; set; } = string.Empty;
    public required List<InformativoNFe> InformativoNFes { get; set; }
    public required List<InformativoPecasTrocadas> InformativoPecasTrocadas { get; set; }
    public required List<InformativoOs> InformativoOs { get; set; }
}