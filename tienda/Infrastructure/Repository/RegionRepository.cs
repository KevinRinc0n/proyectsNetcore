using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repository;

// public class RegionRepository : GenericRepo<Estado>, IEstado
// {
//     private readonly TiendaContext _context;

//     public RegionRepository(TiendaContext context) : base(context)
//     {
//         _context = context;
//     }    

//     public override async Task<IEnumerable<Region>> GetAllAsync()
//     {
//         return await _context.Regiones
//             .Include(r => r.Region);
//     }
// }
