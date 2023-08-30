using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entitites;

namespace Infrastructure.Repository;

public class VehiculoRepository : GenericRepo<Vehiculo>, IVehiculo
{
    private readonly TallerContext _context;
    public VehiculoRepository(TallerContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Vehiculo>> GetAllAsync()
    {
        return await _context.Vehiculos
            .Include(p => p.Empleados)
            .ToListAsync();
    }

    public override async Task<Vehiculo> GetByIdAsync(int id)
    {
        return await _context.Vehiculos
        .Include(p => p.Empleados)
        .FirstOrDefaultAsync(p => p.Placa == id);
    }
}