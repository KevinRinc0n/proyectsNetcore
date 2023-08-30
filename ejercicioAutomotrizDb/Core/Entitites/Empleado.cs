using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class Empleado : TipoPersona
{
    public string Especialidad { get; set; }
    public ICollection<Cliente> Clientes { get; set; } = new HashSet<Cliente>();
    public int IdTipoPersonFk { get; set; }
    public TipoPersona TipoPersona { get; set; }

}
