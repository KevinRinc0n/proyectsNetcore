using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core.Entitites;

public class Vehiculo
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public string Color { get; set; }
    public double Kilometraje { get; set; }
    public ICollection<Empleado> Empleados { get; set; } = new HashSet<Empleado>();
    public int IdClienteFk { get; set; }
    public Cliente Cliente { get; set; }

}
