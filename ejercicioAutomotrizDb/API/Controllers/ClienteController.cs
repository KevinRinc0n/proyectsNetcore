using Core.Entitites;
using Core.Interfaces;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ClienteController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;
    
    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;   
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var clientes = await unitofwork.Clientes.GetAllAsync();
        return mapper.Map<List<ClienteDto>>(clientes);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var cliente = await unitofwork.Clientes.GetByIdAsync(id);
        return mapper.Map<ClienteDto>(cliente);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Cliente>> Post(ClienteDto clienteDto)
    {
        var cliente = this.mapper.Map<Cliente>(clienteDto);
        this.unitofwork.Clientes.Add(cliente);
        await unitofwork.Clientes.SaveAsync();

        if (cliente == null)
        {
            return BadRequest();
        }
        clienteDto.Id = cliente.Id;
        return CreatedAtAction(nameof(Post), new {id = clienteDto.Id}, clienteDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ClienteDto>> Put (int id, [FromBody]ClienteDto clienteDto)
    {
        if(clienteDto == null)
            return NotFound();
        
        var cliente = this.mapper.Map<Cliente>(clienteDto);
        unitofwork.Clientes.Update(cliente);
        await unitofwork.SaveAsync();
        return clienteDto;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var cliente = await unitofwork.Clientes.GetByIdAsync(id);

        if (cliente == null)
            return Notfound();

        unitofwork.Clientes.Remove(cliente);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
