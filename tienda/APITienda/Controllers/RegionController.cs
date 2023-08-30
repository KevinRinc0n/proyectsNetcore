// using Core.Entities;
// using Core.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace APITienda.Controllers;

// public class RegionController : BaseApiController
// {
//     private IUnitOfWork unitofwork;

//     public RegionController(IUnitOfWork unitOfWork)
//     {
//         this.unitofwork = unitOfWork;
//     } 

//     [HttpGet]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]

//     public async Task<ActionResult<IEnumerable<Region>>> Get()
//     {
//         var regiones = await unitofwork.Regiones.GetAllAsync();
//         return Ok(regiones);
//     }

//     [HttpGet("Id")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]

//     public async Task<ActionResult<Region>> Get (int id)
//     {
//         var Region = await unitofwork.Regiones.GetByIdAsync(id);
//         return Ok(Region);
//     }

//     [HttpPost]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<Region>> Post (Region region)
//     {
//         unitofwork.Regiones.Add(region);
//         await unitofwork.SaveAsync();

//         if (region == null)
//         {
//             return BadRequest();
//         }
//         return CreatedAtAction(nameof(Post), new { id = region.Id}, region);
//     }
// }
