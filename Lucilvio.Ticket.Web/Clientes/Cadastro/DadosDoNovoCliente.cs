using System.Collections.Generic;

namespace Lucilvio.Ticket.Web.Clientes.Cadastro
{
    public class DadosDoNovoCliente
    {
        public DadosDoNovoCliente()
        {
            this.Contatos = new List<Contato>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoDaSenha { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }

        public class Contato
        {
            public string Valor { get; set; }
            public string Tipo { get; set; }
        }
    }
}
