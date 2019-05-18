using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Dominio.Usuarios;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Lucilvio.Ticket.Infra.RepositoriosEf
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
