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
    private bool estado;
    private Clientes cliente;

    public Pedidos(string nombre, string direccion, int telefono, string referenciaDireccion)
    {
        this.cliente = new Clientes(){
            Nombre = nombre, 
            Direccion = direccion, 
            Telefono = telefono, 
            ReferenciaDireccion = referenciaDireccion
        };
        
    }

    public int NumPedido { get => numPedido; set => numPedido = value; }
    public int Observaciones { get => observaciones; set => observaciones = value; }
    public bool Estado { get => estado; set => estado = value; }
    
    }
public class Cadete{


    private int id;
    private string nombre;
    private string direccion;
    private long telefono;
    private List<Pedidos> pedido = new List<Pedidos>();

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public long Telefono { get => telefono; set => telefono = value; }
    public void AgregarPedido(Pedidos pedidos){
        pedido.Add(pedidos);
    }
}
public class Cadeteria{
    private string nombre;
    private long telefono;
    private List<Cadete> cadete;

    public string Nombre { get => nombre; set => nombre = value; }
    public long Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> Cadete { get => cadete; set => cadete = value; }
}