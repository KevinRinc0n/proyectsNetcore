using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repository;

public class ProductoRepository : GenericRepo<Producto>, IProducto
{
    private readonly TiendaContext _context;
    
    public ProductoRepository(TiendaContext context) : base (context)
    {
        _context = context;
    }

    public override async  Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .Include(p => p.Personas)
            .ToListAsync();
    }

    public override async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Productos
            .Include(p => p.Personas)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
