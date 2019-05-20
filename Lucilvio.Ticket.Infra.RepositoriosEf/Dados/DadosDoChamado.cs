using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucilvio.Ticket.Infra.Dados
{
    [Table("Chamados")]
    public class DadosDoChamado : Dados
    {
        public int Protocolo { get; set; }
        [MaxLength(2048)]
        public string Descricao { get; set; }
        public DateTime DataDaAbertura { get; set; }

        [ForeignKey("ClienteId")]
        public DadosDoCliente Cliente { get; set; }

        public ICollection<DadosDeResposta> Respostas { get; set; }

    }
}