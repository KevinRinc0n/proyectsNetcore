using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configuration;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estado");

        
        builder.Property(e => e.NombreEstado)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Estados)
        .HasForeignKey(p => p.IdPaisFk);
    }
}
