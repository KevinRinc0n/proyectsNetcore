using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entitites; 

namespace Infrastructure.Repository;

public class EmpleadoRepository : GenericRepo<Empleado>, IEmpleado
{
    private readonly TallerContext _context;
    public EmpleadoRepository(TallerContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados
            .Include(p => p.Clientes)
            .ToListAsync();
    }

    public override async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Empleados
        .Include(p => p.Clientes)
        .FirstOrDefaultAsync(p => p.Id == id);
    } 
} 
