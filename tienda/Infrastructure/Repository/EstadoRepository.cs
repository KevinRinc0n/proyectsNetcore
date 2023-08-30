using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repository;

public class EstadoRepository : GenericRepo<Estado>, IEstado
{
    private readonly TiendaContext _context;
    
    public EstadoRepository(TiendaContext context): base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Estado>> GetAllAsync()
    {
        return await _context.Estados
            .Include(e => e.Regiones)
            .ToListAsync();
    }

    public override async Task<Estado> GetByIdAsync(int id)
    {
        return await _context.Estados
        .Include(p => p.Regiones)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
