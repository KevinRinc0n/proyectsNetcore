using Core.Entities;
using AutoMapper;
using Core.Interfaces;
using APITienda.Dtos;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;

namespace APITienda.Controllers;

public class EstadoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;
    public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Estado>>> Get()
    {
        var estados = await unitofwork.Estados.GetAllAsync();
        return mapper.Map<List<EstadoDto>>(estados);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EstadosDto>> Get (int id)
    {
        var estado = await unitofwork.Estados.GetByIdAsync(id);
        return mapper.Map<EstadosDto>(estado);
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
        return CreatedAtAction(nameof(Post), new { id = EstadoDto.Id}, EstadoDto);
    }

    [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody]EstadoDto estadoDto){

            if(estadoDto == null)
            {
                return NotFound();
            }
            var estado = mapper.Map<Estado>(estadoDto);
            unitofWork.Estados.Update(estado);
            await unitofWork.SaveAsync();
            return estadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EstadoDto>> Delete(int id)
        {
            var estados = await unitofWork.Estados.GetByIdAsync(id);
            if (estados == null)
            {
                return NotFound();
            }
            unitofWork.Estados.Remove(estados);
            await unitofWork.SaveAsync();

            return NoContent();
        }

        private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
