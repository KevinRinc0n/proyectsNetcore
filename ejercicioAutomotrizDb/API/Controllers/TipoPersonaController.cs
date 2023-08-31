using Core.Entitites;
using Core.Interfaces;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoPersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;
    
    public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;   
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
    {
        var tipoPersonas = await unitofwork.TipoPersonas.GetAllAsync();
        return mapper.Map<List<TipoPersonaDto>>(tipoPersonas);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoPersonaDto>> Get(int id)
    {
        var tipoPersona = await unitofwork.TipoPersonas.GetByIdAsync(id);
        return mapper.Map<TipoPersonaDto>(tipoPersona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto tipoPersonaDto)
    {
        var tipoPersona = this.mapper.Map<TipoPersonaDto>(tipoPersonaDto);
        this.unitofwork.TipoPersonas.Add(tipoPersona);
        await unitofwork.TipoPersonas.SaveAsync();

        if (tipoPersona == null)
            return BadRequest();

        tipoPersonaDto.Id = tipoPersona.Id;
        return CreatedAtAction(nameof(Post), new {id = tipoPersonaDto.Id}, tipoPersonaDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersonaDto>> Put (int id, [FromBody]TipoPersonaDto tipoPersonaDto)
    {
        if (tipoPersonaDto == null)
            return Notfound();

        var tipoPersona = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        unitofwork.TipoPersonas.Update(tipoPersona);
        await unitofwork.SaveAsync();
        return tipoPersonaDto;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tipoPersona = await unitofwork.TipoPersonas.GetByIdAsync(id);

        if (tipoPersona == null)
            return Notfound();

        unitofwork.TipoPersonas.Remove(tipoPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}