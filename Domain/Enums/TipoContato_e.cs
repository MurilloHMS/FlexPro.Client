using System.ComponentModel.DataAnnotations;

namespace FlexPro.Client.Domain.Enums;

public enum TipoContato_e
{
    [Display(Name = "Dúvida sobre produtos")]
    DuvidaProduto = 1,
    [Display(Name = "Suporte técnico")] SuporteTecnico = 2,

    [Display(Name = "Solicitação de orçamento")]
    SolicitacaoOrcamento = 3,

    [Display(Name = "Representação comercial")]
    RepresentacaoComercial = 4,
    [Display(Name = "Trabalhe conosco")] TrabalheConosco = 5,

    [Display(Name = "Consultoria especializada")]
    ConsultoriaEspecializada = 6,

    [Display(Name = "Agendar visita técnica")]
    VisitaTecnica = 7,

    [Display(Name = "Informações sobre certificações")]
    InformacoesCertificacoes = 8,

    [Display(Name = "Problemas com pedido ou entrega")]
    ProblemaPedidoEntrega = 9,
    [Display(Name = "Outros")] Outros = 10
}