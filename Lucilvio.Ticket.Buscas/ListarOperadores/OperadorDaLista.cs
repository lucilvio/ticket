using System;

namespace Lucilvio.Ticket.Buscas.ListarOperadores
{
    public class OperadorDaLista
    {
        public OperadorDaLista(int id, string nome, string email, bool ativo, DateTime dataDoCadastro)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Ativo = ativo;
            this.DataDoCadastro = dataDoCadastro.ToString();
        }

        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string DataDoCadastro { get; }
        public bool Ativo { get; }
    }
}
