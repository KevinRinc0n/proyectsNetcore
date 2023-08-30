using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.ToTable("tipoPersona");

        builder.Property(t => t.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(t => t.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(t => t.Apellido)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(t => t.Numero)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(t => t.Diagnostico)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(t => t.Clientes)
        .IsRequired();

        builder.Property(t => t.Empleados)
        .IsRequired();
    }
}
