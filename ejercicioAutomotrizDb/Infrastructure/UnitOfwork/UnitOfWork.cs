using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly TallerContext context;
    private VehiculoRepository _vehiculos;
    private ClienteRepository _clientes;
    private EmpleadoRepository _empleados;
    private TipoPersonaRepository _tipoPersonas;
    private FacturaRepository _facturas;
    private DetalleAprobacionRepository _detallesAprobaciones;


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

    public IEmpleado Empleados
    {
        get{
            if(_empleados == null)
            {
                _empleados = new EmpleadoRepository(context);
            }
            return _empleados;
        }
    }

    public ITipoPersona TipoPersonas
    {
        get{
            if(_tipoPersonas == null)
            {
                _tipoPersonas = new TipoPersonaRepository(context);
            }
            return _tipoPersonas;
        }
    }

    public IFactura Facturas
    {
        get{
            if(_facturas == null)
            {
                _facturas = new FacturaRepository(context);
            }
            return _facturas;
        }
    }

    public IDetalleAprobacion DetallesAprobaciones
    {
        get{
            if(_detallesAprobaciones == null)
            {
                _detallesAprobaciones = new DetalleAprobacionRepository(context);
            }
            return _detallesAprobaciones;
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
