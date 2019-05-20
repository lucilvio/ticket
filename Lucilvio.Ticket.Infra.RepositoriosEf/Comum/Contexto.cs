using System.Reflection;
using Lucilvio.Ticket.Infra.Dados;
using Microsoft.EntityFrameworkCore;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Comum
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            Seed.Executar(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DadosDoChamado> Chamados { get; set; }
        public DbSet<DadosDoCliente> Clientes { get; set; }
        public DbSet<DadosDoOperador> Operadores { get; set; }
        public DbSet<DadosDoUsuario> Usuarios { get; set; }
    }
}
