using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configuration;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("region");

        builder.Property(e => e.NombreRegion)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.Regiones)
        .HasForeignKey(p => p.IdEstadoFk);
    }
}

