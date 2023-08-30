namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IVehiculo Vehiculos { get; }
    ICliente Clientes { get; }
    object Empleados { get; }

    Task<int> SaveAsync();
}
