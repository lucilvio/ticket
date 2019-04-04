using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Web.Chamados
{
    public class ComandoParaAbrirChamado : IComando
    {
        public ComandoParaAbrirChamado(string cliente, string descricao)
        {
            this.Cliente = cliente;
            this.Descricao = descricao;
        }

        public string Cliente { get; }
        public string Descricao { get; }
    }
}
