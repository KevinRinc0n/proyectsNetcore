using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly TallerContext context;
    private VehiculoRepository _vehiculos;
    private ClienteRepository _clientes;


    public UnitOfWork(TallerContext _context)
    {
        context = _context;
    }
    public IVehiculo Vehiculos
    {
        get{
            if(_vehiculos == null)
            {
                _vehiculos = new VehiculoRepository(context);
            }
            return _vehiculos;
        }
    }

    public ICliente Clientes
    {
        get{
            if(_clientes == null)
            {
                _clientes = new ClienteRepository(context);
            }
            return _clientes;
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int>SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
