using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucilvio.Ticket.Infra.Dados
{
    [Table("Chamados")]
    public class DadosDoChamado : Dados
    {
        public int Protocolo { get; private set; }
        [MaxLength(2048)]
        public string Descricao { get; private set; }
        public DateTime DataDaAbertura { get; private set; }

        [ForeignKey("ClienteId")]
        public DadosDoCliente Cliente { get; private set; }

        public ICollection<DadosDeResposta> Respostas { get; set; }

    }
}