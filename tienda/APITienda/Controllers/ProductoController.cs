using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APITienda.Controllers;

public class ProductoController : BaseApiController
{
    private IUnitOfWork unitofwork;

    public ProductoController(IUnitOfWork unitOfWork)
    {
        this.unitofwork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Producto>>> Get() 
    {
        var productos = await unitofwork.Productos.GetAllAsync();
        return Ok(productos);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Producto>>> Get (int id)
    {
        var producto = await this.unitofwork.Productos.GetByIdAsync(id);
        return Ok(producto);
    }  

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Post(Producto producto)
    {
        unitofwork.Productos.Add(producto);
        await unitofwork.SaveAsync();

        if(producto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = producto.Id}, producto);
    }
}
