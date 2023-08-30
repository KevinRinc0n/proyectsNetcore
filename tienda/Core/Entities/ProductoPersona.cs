namespace Core.Entities;

public class ProductoPersona
{
    public int IdProducto { get; set;}
    public Producto Producto { get; set; }
    public int IdPersona { get; set; }
    public Persona Persona { get; set; }
    
}
