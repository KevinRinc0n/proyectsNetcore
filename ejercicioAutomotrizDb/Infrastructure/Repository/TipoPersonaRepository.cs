using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entitites; 

namespace Infrastructure.Repository;

public class TipoPersonaRepository : GenericRepo<TipoPersona>, ITipoPersona
{
    private readonly TallerContext _context;
    public TipoPersonaRepository(TallerContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
    {
        return await _context.TipoPersonas
            .Include(p => p.Empleados)
            .Include(p => p.Clientes)
            .ToListAsync();
    }

    public override async Task<TipoPersona> GetByIdAsync(int id)
    {
        return await _context.TipoPersonas
        .Include(p => p.Empleados)
        .Include(p => p.Clientes)
        .FirstOrDefaultAsync(p => p.Id == id);
    } 
}