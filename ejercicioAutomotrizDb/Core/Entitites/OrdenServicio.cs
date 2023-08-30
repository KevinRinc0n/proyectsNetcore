using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class OrdenServicio : Vehiculo
{
    public string NumeroOrden { get; set; }
    public DateTime FechaOrden { get; set; }
}
