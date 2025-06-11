using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Persistence.Configuracoes
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100);

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Endereco)
                     .HasColumnName("Email")
                     .IsRequired()
                     .HasMaxLength(255);
            });
        }
    }
}
