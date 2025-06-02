using FlexPro.Client.Domain.Enums;

namespace FlexPro.Client.Models;

public class Embalagem
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public TipoEmbalagem_e TipoEmbalagem { get; set; }
    public int Tamanho { get; set; }
}