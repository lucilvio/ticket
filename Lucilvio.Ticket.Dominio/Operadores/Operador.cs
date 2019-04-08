using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Usuarios;

namespace Lucilvio.Ticket.Dominio.Operadores
{
    public class Operador : Entidade
    {
        private Operador()
        {
        }

        public Operador(string nome, string login)
        {
            this.Nome = nome;
            this.Usuario = new Usuario(login);
        }

        public string Nome { get; }
        public Usuario Usuario { get; set; }

        public Chamado AbrirChamado(Cliente cliente, Protocolo.Gerador geradorDeProtocolo, string descricao)
        {
            return new Chamado(cliente, geradorDeProtocolo.NovoProtocolo(), descricao);
        }

        public void ResponderAoChamado(Chamado novoChamado, string resposta)
        {
            novoChamado.AdicionarResposta(this, resposta);
        }
    }
}