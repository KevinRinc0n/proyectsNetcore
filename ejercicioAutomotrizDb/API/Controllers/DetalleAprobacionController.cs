using Core.Entitites;
using Core.Interfaces;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DetalleAprobacionController : BaseApiController 
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;
    
    public DetalleAprobacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;   
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DetalleAprobacionDto>>> Get()
    {
        var detallesAprobacion = await unitofwork.DetallesAprobaciones.GetAllAsync();
        return mapper.Map<List<DetalleAprobacionDto>>(detallesAprobacion);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DetalleAprobacionDto>> Get(int id)
    {
        var detalleAprobacion = await unitofwork.DetallesAprobaciones.GetByIdAsync(id);
        return mapper.Map<DetalleAprobacionDto>(detalleAprobacion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DetalleAprobacion>> Post(DetalleAprobacionDto detalleAprobacionDto)
    {
        var detalleAprobacion = this.mapper.Map<DetalleAprobacion>(detalleAprobacionDto);
        this.unitofwork.DetallesAprobaciones.Add(detalleAprobacion);
        await unitofwork.DetallesAprobaciones.SaveAsync();

        if (detalleAprobacion == null)
        {
            return BadRequest();
        }
        detalleAprobacionDto.Id = detalleAprobacion.Id;
        return CreatedAtAction(nameof(Post), new {id = detalleAprobacionDto.Id}, detalleAprobacionDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DetalleAprobacionDto>> Put (int id, [FromBody]DetalleAprobacionDto detalleAprobacionDto)
    {
        if(detalleAprobacionDto == null)
            return NotFound();
        
        var detalleAprobacion = this.mapper.Map<DetalleAprobacion>(detalleAprobacionDto);
        unitofwork.DetallesAprobaciones.Update(detalleAprobacion);
        await unitofwork.SaveAsync();
        return detalleAprobacionDto;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var detalleAprobacion = await unitofwork.DetallesAprobaciones.GetByIdAsync(id);

        if (detalleAprobacion == null)
            return Notfound();

        unitofwork.DetallesAprobaciones.Remove(detalleAprobacion);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}