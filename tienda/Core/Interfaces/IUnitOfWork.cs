namespace Core.Interfaces;

public interface IUnitOfWork: IDisposable
{
    IPais Paises { get; }
    IEstado Estados { get; }
    IPersona Personas { get; }
    IProducto Productos { get; }
    // IRegion Regiones { get; }

    Task<int> SaveAsync();
}
