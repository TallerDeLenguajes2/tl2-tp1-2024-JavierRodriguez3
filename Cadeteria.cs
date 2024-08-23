namespace Cadeteria;

public class Clientes{
    private string nombre;
    private string direccion;
    private int telefono;
    private string referenciaDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string ReferenciaDireccion { get => referenciaDireccion; set => referenciaDireccion = value; }
}
public class Pedidos{
    private int numPedido;
    private int observaciones;
    private Clientes cliente;
    private bool estado;
    }
public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private long telefono;
    private List<Pedidos> pedidos;
}
public class Cadeteria{
    private string nombre;
    private long telefono;
    private List<Cadete> cadete;
}