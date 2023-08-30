using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APITienda.Controllers;

public class EstadoController : BaseApiController
{
    private IUnitOfWork unitofwork;

    public EstadoController(IUnitOfWork unitOfWork)
    {
        this.unitofwork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Estado>>> Get()
    {
        var estados = await unitofwork.Estados.GetAllAsync();
        return Ok(estados);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Estado>> Get (int id)
    {
        var estado = await unitofwork.Estados.GetByIdAsync(id);
        return Ok(estado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Estado>> Post (Estado estado)
    {
        unitofwork.Estados.Add(estado);
        await unitofwork.SaveAsync();

        if (estado == null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = estado.Id}, estado);
    }
}
