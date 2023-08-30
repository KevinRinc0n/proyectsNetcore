using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repository;

public class PersonaRepository : GenericRepo<Persona>, IPersona
{
    private readonly TiendaContext _context;
    public PersonaRepository(TiendaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
            .Include(p => p.Productos)
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .Include(p => p.Productos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
} 