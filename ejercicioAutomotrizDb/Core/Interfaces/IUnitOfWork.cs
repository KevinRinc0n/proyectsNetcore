namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IVehiculo Vehiculos { get; }
    ICliente Clientes { get; }

    Task<int> SaveAsync();
}
