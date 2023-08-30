using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{ 
    public void Configure(EntityTypeBuilder<Factura> builder)
    {
        builder.ToTable("factura");

        builder.Property(f => f.NumeroOrden)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(f => f.NumeroFactura)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(f => f.Item)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(f => f.Repuesto)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(f => f.Valor)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(f => f.Cantidad)
        .IsRequired()
        .HasColumnType("int");
    }
}
