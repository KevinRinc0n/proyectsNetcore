using Core.Entitites;
using Core.Interfaces;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class FacturaController : BaseApiController 
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;
    
    public FacturaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;   
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<FacturaDto>>> Get()
    {
        var facturas = await unitofwork.Facturas.GetAllAsync();
        return mapper.Map<List<FacturaDto>>(facturas);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<FacturaDto>> Get(int id)
    {
        var factura = await unitofwork.Facturas.GetByIdAsync(id);
        return mapper.Map<FacturaDto>(factura);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Factura>> Post(FacturaDto facturaDto)
    {
        var factura = this.mapper.Map<Factura>(facturaDto);
        this.unitofwork.Facturas.Add(factura);
        await unitofwork.Facturas.SaveAsync();

        if (factura == null)
        {
            return BadRequest();
        }
        facturaDto.Id = factura.Id;
        return CreatedAtAction(nameof(Post), new {id = facturaDto.Id}, facturaDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<FacturaDto>> Put (int id, [FromBody]FacturaDto facturaDto)
    {
        if(facturaDto == null)
            return NotFound();
        
        var factura = this.mapper.Map<Factura>(facturaDto);
        unitofwork.Facturas.Update(factura);
        await unitofwork.SaveAsync();
        return facturaDto;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var factura = await unitofwork.Facturas.GetByIdAsync(id);

        if (factura == null)
            return Notfound();

        unitofwork.Facturas.Remove(factura);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}    