using API.Dtos;
using Core.Entities;

namespace APITienda.Dtos;

public class PaisDto
{
    public int Id { get; set; }
    public string NombrePais { get; set; }
    public List<EstadoDto> Estados { get; set; } 
}
