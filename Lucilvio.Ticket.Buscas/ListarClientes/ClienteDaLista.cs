using System;

namespace Lucilvio.Ticket.Buscas.ListarClientes
{
    public class ClienteDaLista
    {
        public ClienteDaLista()
        {
        }

        public ClienteDaLista(string nome, string email, DateTime dataDoCadastro) : this()
        {
            this.Nome = nome;
            this.Email = email;
            this.DataDoCadastro = dataDoCadastro.ToString();
        }

        public int Id { get; set; }
        public string Nome { get; }
        public string Email { get; }
        public string DataDoCadastro { get; }
    }
}