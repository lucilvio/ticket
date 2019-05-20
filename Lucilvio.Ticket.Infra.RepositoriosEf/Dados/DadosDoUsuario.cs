using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucilvio.Ticket.Infra.Dados
{
    [Table("Usuarios")]
    public class DadosDoUsuario : Dados
    {
        [MaxLength(512)]
        public string Nome { get; set; }
        [MaxLength(512)]
        public string Email { get; set; }
        [MaxLength(512)]
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int Perfil { get; set; }
        public DateTime DataDoCadastro { get; set; }
    }
}