using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DetalleAprobacionConfiguration : IEntityTypeConfiguration<DetalleAprobacion>
{
    public void Configure(EntityTypeBuilder<DetalleAprobacion> builder)
    {
        builder.ToTable("detalleAprobacion");

        builder.Property(d => d.Item)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(d => d.Repuesto)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(d => d.Valor)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(d => d.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(d => d.Estado)
        .IsRequired()
        .HasMaxLength(50);


        
    }
}
