using Lucilvio.Ticket.Dominio.Chamados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Mapeamentos
{
    public class MapeamentoDeChamado : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder.ToTable("Chamados");
            builder.HasKey("Id");
            builder.OwnsOne(p => p.Protocolo).Property(p => p.Valor).HasColumnName("Protocolo");
        }
    }
}
