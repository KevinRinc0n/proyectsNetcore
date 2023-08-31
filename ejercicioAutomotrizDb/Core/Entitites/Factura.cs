using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class Factura : DetalleFactura
{
    public int NumeroOrden { get; set; }
    public int NumeroFactura { get; set; }
    public int IdCliente { get; set; }
}
