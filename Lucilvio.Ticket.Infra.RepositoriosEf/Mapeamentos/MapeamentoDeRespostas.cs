using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Operadores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Mapeamentos
{
    public class MapeamentoDeRespostas : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.ToTable("Respostas");
            builder.HasKey("Id");
            builder.Property(p => p.Texto).HasMaxLength(4000);
            builder.Property(p => p.Data);
            builder.HasOne<Operador>("Operador");
            builder.HasOne<Chamado>("Chamado").WithMany(c => c.Respostas).HasForeignKey("IdChamado").IsRequired();
        }
    }
}
