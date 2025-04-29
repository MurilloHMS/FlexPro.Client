﻿namespace FlexPro.Client.Models
{
    public class Revisao
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public int Kilometragem { get; set; }
        public string NotaFiscal { get; set; }
        public string Tipo { get; set; }
        public string Motorista { get; set; }
        public string? Observacao { get; set; }
        // Chaves estrangeiras
        public int LocalId { get; set; } // Propriedade para a chave estrangeira
        public int VeiculoId { get; set; } // Propriedade para a chave estrangeira

        // Propriedades de navegação
        public virtual Entidade? Local { get; set; }
        public virtual Veiculo? Veiculo { get; set; }
    }
}
