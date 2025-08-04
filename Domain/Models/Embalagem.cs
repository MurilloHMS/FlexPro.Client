using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Domain.Models;

public class Embalagem
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public TipoEmbalagemE TipoEmbalagem { get; set; }
    public int Tamanho { get; set; }
}