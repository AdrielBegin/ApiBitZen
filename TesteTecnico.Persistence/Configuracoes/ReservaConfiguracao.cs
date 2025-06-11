using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Persistence.Configuracoes
{
    public class ReservaConfiguracao : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reservas");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.DataInicio).IsRequired();

            builder.HasOne(r => r.Usuario)
                   .WithMany(u => u.Reservas)
                   .HasForeignKey(r => r.UsuarioId);

            builder.HasOne(r => r.Sala)
                   .WithMany(s => s.Reservas)
                   .HasForeignKey(r => r.SalaId);
        }
    }
}