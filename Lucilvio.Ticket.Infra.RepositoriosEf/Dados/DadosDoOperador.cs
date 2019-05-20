using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucilvio.Ticket.Infra.Dados
{
    [Table("Operadores")]
    public class DadosDoOperador : Dados
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public bool Ativo { get; set; }

        [ForeignKey("UsuarioId")]
        public DadosDoUsuario Usuario { get; set; }
    }
}