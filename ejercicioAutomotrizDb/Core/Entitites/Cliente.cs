using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class Cliente : TipoPersona
{
    public string Email { get; set; }
    public DateTime FechaRegistro { get; set; }
    public ICollection<Vehiculo> Vehiculos { get; set; } = new HashSet<Vehiculo>(); 
    public int IdTipoPersonaFk { get; set; }
    public TipoPersona TipoPersona { get; set; }

}
