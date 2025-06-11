using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Persistence.Configuracoes
{
    public class SalaConfiguracao : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("Salas");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
