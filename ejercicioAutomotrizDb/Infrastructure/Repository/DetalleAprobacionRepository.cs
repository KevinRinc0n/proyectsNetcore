using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entitites; 

namespace Infrastructure.Repository;

public class DetalleAprobacionRepository : GenericRepo<DetalleAprobacion>, IDetalleAprobacion
{
    private readonly TallerContext _context;
    public DetalleAprobacionRepository(TallerContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleAprobacion>> GetAllAsync()
    {
        return await _context.DetallesAprobacion
            .Include(p => p.)
            .ToListAsync();
    }

    public override async Task<DetalleAprobacion> GetByIdAsync(int id)
    {
        return await _context.DetallesAprobacion
        .Include(p => p.)
        .FirstOrDefaultAsync(p => p.Id == id);
    } 
}