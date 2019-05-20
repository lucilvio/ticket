using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucilvio.Ticket.Infra.Dados
{
    [Table("Clientes")]
    public class DadosDoCliente : Dados
    {
        public DadosDoCliente()
        {
            this.Chamados = new Collection<DadosDoChamado>();
            this.Contatos = new Collection<DadosDoContato>();
        }

        [MaxLength(512)]
        public string Nome { get; set; }
        [MaxLength(512)]
        public string Email { get; set; }
        public DateTime DataDoCadastro { get; set; }

        [ForeignKey("UsuarioId")]
        public DadosDoUsuario Usuario { get; set; }

        public ICollection<DadosDoChamado> Chamados { get; set; }
        public ICollection<DadosDoContato> Contatos { get; set; }
    }
}