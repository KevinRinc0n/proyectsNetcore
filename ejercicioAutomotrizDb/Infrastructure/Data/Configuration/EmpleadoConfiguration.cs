using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

        builder.Property(e => e.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Apellido)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Numero)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(e => e.Especialidad)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Clientes)
        .IsRequired();

        builder.Property(e => e.Diagnostico)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(t => t.TipoPersona)
        .WithMany(t => t.Empleados)
        .HasForeignKey(t => t.IdTipoPersonFk);
    }
}
