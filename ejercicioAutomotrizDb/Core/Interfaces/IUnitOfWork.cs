namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IVehiculo Vehiculos { get; }
    ICliente Clientes { get; }
    object Empleados { get; }
    object TipoPersonas { get; }

    Task<int> SaveAsync();
}
