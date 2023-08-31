using Core.Entitites;
using Core.Interfaces;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmpleadoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;
    
    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;   
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var empleados = await unitofwork.Empleados.GetAllAsync(); 
        return mapper.Map<List<EmpleadoDto>>(empleados);
    }
    
    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var empleado = await unitofwork.Empleados.GetByIdAsync(id);
        return mapper.Map<EmpleadoDto>(empleado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async  Task<ActionResult<Empleado>> Post(EmpleadoDto empleadoDto)
    {
        var empleado = this.mapper.Map<Empleado>(empleadoDto);
        this.unitofwork.Empleados.Add(empleado);
        await unitofwork.Empleados.SaveAsync();

        if (empleado == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = empleadoDto.Id}, empleadoDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EmpleadoDto>> Put (int id, [FromBody]EmpleadoDto empleadoDto)
    {
        if (empleadoDto == null)
            return NotFound();
        
        var empleado = this.mapper.Map<Empleado>(empleadoDto);
        unitofwork.Empleados.Update(empleado);
        await unitofwork.SaveAsync();
        return empleadoDto;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var empleado = await unitofwork.Empleados.GetByIdAsync(id);

        if (empleado == null)
            return Notfound();

        unitofwork.Empleados.Remove(empleado);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
