    using Core.Interfaces;
    using Infrastructure.Data;
    using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly TiendaContext context;
    private PaisRepository _paises;
    private EstadoRepository _estados;
    private ProductoRepository _productos;
    private PersonaRepository _personas;
    // private RegionRepository _regiones;

    public UnitOfWork(TiendaContext _context)
    {
        context = _context;
    }

    public IPais Paises
    {
        get{
            if (_paises == null)
            {
                _paises = new PaisRepository(context);
            }
            return _paises;
        }

    }

    public IEstado Estados
    {
        get{
            if (_estados == null)
            {
                _estados = new EstadoRepository(context);
            }
            return _estados;
        }

    }

    public IPersona Personas
    {
        get{
            if (_personas == null)
            {
                _personas = new PersonaRepository(context);
            }
            return _personas;
        }

    }

    public IProducto Productos
    {
        get{
            if (_productos == null)
            {
                _productos = new ProductoRepository(context);
            }
            return _productos;
        }

    }

    // public IRegion Regiones
    // {
    //     get{
    //         if (_regiones == null)
    //         {
    //             _regiones = new RegionRepository(context);
    //         }
    //         return _regiones;
    //     }

    // }

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
