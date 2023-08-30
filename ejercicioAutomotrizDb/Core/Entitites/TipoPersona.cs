using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class TipoPersona : BaseEntity
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public long Numero { get; set; }
    public string Diagnostico { get; set; }
    public ICollection<Cliente> Clientes { get; set; } = new HashSet<Cliente>();
    public ICollection<Empleado> Empleados { get; set; } = new HashSet<Empleado>(); 

}
