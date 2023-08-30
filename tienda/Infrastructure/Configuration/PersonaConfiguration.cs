using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(p => p.IdPersona)
        .IsRequired()
        .HasMaxLength(15);

        builder.Property(p => p.NombrePersona)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.FechaNac)
            .IsRequired()
            .HasColumnType("Date");    

        builder.
        HasOne(p => p.TipoPersona)
        .WithMany(tp => tp.Personas)
        .HasForeignKey(p => p.IdTipoPerFk);
        
        builder
        .HasMany(p => p.Productos)
        .WithMany(p => p.Personas)
        .UsingEntity<ProductoPersona>(
            j => j
            .HasOne(pt => pt.Producto)
            .WithMany(t => t.ProductosPersonas)
            .HasForeignKey(pt => pt.IdProducto),
            j => j
            .HasOne(pt => pt.Persona)
            .WithMany(p => p.ProductosPersonas)
            .HasForeignKey(pt => pt.IdPersona),
            j =>
            {
                j.HasKey(t => new { t.IdPersona, t.IdProducto });
            }
        );
    }
}
