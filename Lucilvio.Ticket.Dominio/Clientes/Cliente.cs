using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Usuarios;
using System.Collections.Generic;
using System.Linq;

namespace Lucilvio.Ticket.Dominio.Clientes
{
    public class Cliente : Entidade
    {
        private Cliente()
        {
            this.Chamados = new List<Chamado>();
        }

        public Cliente(string login, string nome, string senha) : this()
        {
            this.Nome = nome;
            this.Usuario = new Usuario(login, senha);
        }

        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
        public IList<Chamado> Chamados { get; set; }

        public Chamado AbrirChamado(Protocolo protocolo, string descricao)
        {
            var novoChamado = new Chamado(this, protocolo, descricao);
            this.Chamados.Add(novoChamado);
            
            return novoChamado;
        }
    }
}