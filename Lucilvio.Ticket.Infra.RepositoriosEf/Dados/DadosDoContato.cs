using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucilvio.Ticket.Infra.Dados
{
    [Table("ContatosDeClientes")]
    public class DadosDoContato : Dados
    {
        [MaxLength(512)]
        public string Valor { get; set; }
        public int Tipo { get; set; }

        [ForeignKey("ClienteId")]
        public DadosDoCliente Cliente { get; set; }
    }
}