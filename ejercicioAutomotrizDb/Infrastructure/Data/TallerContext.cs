using System.Reflection;
using Core.Entitites;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;

public class TallerContext : DbContext
{
    public TallerContext(DbContextOptions<TallerContext> options) : base(options)
    {
    }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<TipoPersona> TipoPersonas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
