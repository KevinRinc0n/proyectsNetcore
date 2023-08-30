using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("pais");
        builder.Property(p => p.NombrePais)
            .IsRequired()
            .HasMaxLength(50); 
    }
}
