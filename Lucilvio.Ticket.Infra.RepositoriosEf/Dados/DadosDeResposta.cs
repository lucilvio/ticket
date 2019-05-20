using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucilvio.Ticket.Infra.Dados
{
    [Table("RespostasDosChamados")]
    public class DadosDeResposta : Dados
    {
        [MaxLength(1024)]
        public string Texto { get; set; }
        public DateTime Data { get; set; }


        [ForeignKey("ChamadoId")]
        public DadosDoChamado Chamado { get; set; }

        [ForeignKey("OperadorId")]
        public DadosDoOperador Operador { get; set; }
    }
}