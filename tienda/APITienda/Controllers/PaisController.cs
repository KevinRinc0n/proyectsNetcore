using Core.Entities;
using AutoMapper;
using Core.Interfaces;
using APITienda.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace APITienda.Controllers;

public class PaisController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var paises = await unitofwork.Paises.GetAllAsync();
        return mapper.Map<List<PaisDto>>(paises);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Get(int id)
    {
        var pais = await unitofwork.Paises.GetByIdAsync(id);
        return mapper.Map<PaisDto>(pais);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
    {
        var pais = this.mapper.Map<Pais>(paisDto);
        this.unitofwork.Paises.Add(pais);
        await unitofwork.SaveAsync();
        if (pais == null){
            return BadRequest();
        }
        paisDto.Id = pais.Id;
        return CreatedAtAction(nameof(Post), new { id = paisDto.Id }, paisDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PaisDto>> Put (int id, [FromBody]PaisDto paisDto)
    {
        if(paisDto == null)
            return NotFound();

        var pais = this.mapper.Map<Pais>(paisDto);
        unitofwork.Paises.Update(pais);
        await unitofwork.SaveAsync();
        return paisDto;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var pais = await unitofwork.Paises.GetByIdAsync(id);

        if (pais == null)
        {
            return Notfound();
        }

        unitofwork.Paises.Remove(pais);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }

}
