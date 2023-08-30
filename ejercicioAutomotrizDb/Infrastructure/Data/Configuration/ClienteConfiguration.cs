using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(c => c.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Apellido)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Diagnostico)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Numero)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(c => c.Email)
        .HasMaxLength(50);

        builder.Property(c => c.FechaRegistro)
        .HasColumnType("Date");    

        builder.Property(c => c.Vehiculos)
        .IsRequired();
        

        builder.HasOne(t => t.TipoPersona)
        .WithMany(t => t.Clientes)
        .HasForeignKey(t => t.IdTipoPersonaFk);
    }
}
