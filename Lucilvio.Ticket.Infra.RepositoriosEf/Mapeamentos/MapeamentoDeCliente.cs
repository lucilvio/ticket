using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Mapeamentos
{
    public class MapeamentoDeCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(256);
        }
    }
}
