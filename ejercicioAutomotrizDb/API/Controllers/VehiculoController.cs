using Core.Entitites;
using Core.Interfaces;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class VehiculoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;
    
    public VehiculoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;   
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    
    public async Task<ActionResult<IEnumerable<VehiculoDto>>> Get()
    {
        var vehiculos = await unitofwork.Vehiculos.GetAllAsync();
        return mapper.Map<List<VehiculoDto>>(vehiculos);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<VehiculoDto>> Get(int id) 
    {
        var vehiculo = await unitofwork.Vehiculos.GetByIdAsync(id);
        return mapper.Map<VehiculoDto>(vehiculo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Vehiculo>> Post(VehiculoDto vehiculoDto)
    {
        var vehiculo = this.mapper.Map<Vehiculo>(vehiculoDto);
        this.unitofwork.Vehiculos.Add(vehiculo);
        await unitofwork.Vehiculos.SaveAsync();
        if (vehiculo == null)
        {
            return BadRequest();
        }
        vehiculoDto.Placa = vehiculo.Placa;
        return CreatedAtAction(nameof(Post), new {id = vehiculoDto.Placa}, vehiculoDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<VehiculoDto>> Put (int id, [FromBody]VehiculoDto vehiculoDto)
    {
        if(vehiculoDto == null)
            return NotFound();
        
        var vehiculo = this.mapper.Map<Vehiculo>(vehiculoDto);
        unitofwork.Vehiculos.Update(vehiculo);
        await unitofwork.SaveAsync();
        return vehiculoDto;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var vehiculo = await unitofwork.Vehiculos.GetByIdAsync(id);

        if (vehiculo == null)
            return Notfound();

        unitofwork.Vehiculos.Remove(vehiculo);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}