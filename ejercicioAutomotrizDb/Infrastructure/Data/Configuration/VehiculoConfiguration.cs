using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
{
    public void Configure(EntityTypeBuilder<Vehiculo> builder)
    {
        builder.ToTable("vehiculo");

        builder.Property(v => v.Placa)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(v => v.Modelo)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(v => v.Marca)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(v => v.Color)
        .HasMaxLength(50);

        builder.Property(v => v.Kilometraje)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(v => v.Empleados)
        .IsRequired();

        builder.HasOne(e => e.Cliente)
        .WithMany(e => e.Vehiculos)
        .HasForeignKey(e => e.IdClienteFk);
    }
}
