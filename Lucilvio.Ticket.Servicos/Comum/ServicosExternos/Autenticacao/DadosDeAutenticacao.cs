using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Autenticacao
{
    public class DadosDeAutenticacao
    {
        public DadosDeAutenticacao(string nome, string login, string email, string perfil)
        {
            this.Nome = nome;
            this.Login = login;
            this.Email = email;
            this.Perfil = perfil;
        }

        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Perfil { get; private set; }
    }
}
