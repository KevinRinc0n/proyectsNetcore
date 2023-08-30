using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");

        builder.Property(p => p.CodInterno)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Stock)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.StockMin)
        .HasColumnType("int");

        builder.Property(p => p.StockMax)
        .HasColumnType("int");
    }
}
