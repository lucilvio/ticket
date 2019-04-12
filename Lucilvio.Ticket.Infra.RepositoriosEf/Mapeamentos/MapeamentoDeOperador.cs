using Microsoft.EntityFrameworkCore;
using Lucilvio.Ticket.Dominio.Operadores;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Mapeamentos
{
    public class MapeamentoDeOperador : IEntityTypeConfiguration<Operador>
    {
        public void Configure(EntityTypeBuilder<Operador> builder)
        {
            builder.ToTable("Operadores");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(256);
            builder.Property(p => p.Email).HasMaxLength(256);
        }
    }
}
