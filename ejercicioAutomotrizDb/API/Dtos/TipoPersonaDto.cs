using Core.Entitites;

namespace API.Dtos;

public class TipoPersonDto
{
    public List<Cliente> Clientes { get; set; }
    public List<Empleado> Empleados { get; set; } 
}