using Microsoft.EntityFrameworkCore;
using TesteTecnico.Domain.Entidades;
using TesteTecnico.Persistence.Configuracoes;

namespace TesteTecnico.Persistence.Contexto
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new SalaConfiguracao());
            modelBuilder.ApplyConfiguration(new ReservaConfiguracao());
        }
    }
}
