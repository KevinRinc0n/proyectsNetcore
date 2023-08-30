using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites;

public class DetalleFactura
{
    public string Item { get; set; }
     public string Repuesto { get; set; }
    public long Valor  { get; set; } 
    public int Cantidad { get; set; } 
}
