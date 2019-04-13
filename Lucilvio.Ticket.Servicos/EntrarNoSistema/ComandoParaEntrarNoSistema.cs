using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.EntrarNoSistema
{
    public class ComandoParaEntrarNoSistema : IComando
    {
        public ComandoParaEntrarNoSistema(string usuario, string senha)
        {
            this.Usuario = usuario;
            this.Senha = senha;
        }

        public string Usuario { get; }
        public string Senha { get; }
    }
}
