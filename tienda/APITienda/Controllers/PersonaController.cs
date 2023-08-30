using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APITienda.Controllers;

public class PersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;

    public PersonaController(IUnitOfWork unitOfWork)
    {
        this.unitofwork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        var personas = await unitofwork.Personas.GetAllAsync();
        return Ok(personas);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Persona>>> Get (int id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);
        return Ok(persona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Persona>> Post(Persona persona)
    {
        unitofwork.Personas.Add(persona);
        await unitofwork.SaveAsync();

        if(persona == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = persona.Id}, persona);
    }
}