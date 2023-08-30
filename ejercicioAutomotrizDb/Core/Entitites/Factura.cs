using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class Factura : DetalleFactura
{
    public string NumeroOrden { get; set; }
    public string NumeroFactura { get; set; }
    public int IdCliente { get; set; }
}
