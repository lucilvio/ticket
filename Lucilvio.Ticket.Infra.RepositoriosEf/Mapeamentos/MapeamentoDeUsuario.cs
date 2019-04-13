using Microsoft.EntityFrameworkCore;
using Lucilvio.Ticket.Dominio.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Mapeamentos
{
    public class MapeamentoDeUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Login).HasMaxLength(128);
            builder.Property(p => p.Perfil).HasConversion<int>();
        }
    }
}
