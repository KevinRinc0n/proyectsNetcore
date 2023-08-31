using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entitites; 

namespace Infrastructure.Repository;

public class FacturaRepository : GenericRepo<Factura>, IFactura
{
    private readonly TallerContext _context;
    public FacturaRepository(TallerContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Factura>> GetAllAsync()
    {
        return await _context.Facturas
            .Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Factura> GetByIdAsync(int id)
    {
        return await _context.Facturas
        .Include(p => p.)
        .FirstOrDefaultAsync(p => p.Id == id);
    } 
}