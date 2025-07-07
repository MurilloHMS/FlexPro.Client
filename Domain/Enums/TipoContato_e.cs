using System.ComponentModel.DataAnnotations;

namespace FlexPro.Client.Domain.Enums;

public enum TipoContato_e
{
    [Display(Name = "Dúvida sobre produtos")]
    DuvidaProduto
    [Display(Name = "Suporte técnico")] SuporteTecnico

    [Display(Name = "Solicitação de orçamento")]
    SolicitacaoOrcamento

    [Display(Name = "Representação comercial")]
    RepresentacaoComercial
    
    [Display(Name = "Trabalhe conosco")] 
    TrabalheConosco

    [Display(Name = "Consultoria especializada")]
    ConsultoriaEspecializada

    [Display(Name = "Agendar visita técnica")]
    VisitaTecnica

    [Display(Name = "Informações sobre certificações")]
    InformacoesCertificacoes

    [Display(Name = "Problemas com pedido ou entrega")]
    ProblemaPedidoEntrega
    [Display(Name = "Outros")] 
    Outros
}