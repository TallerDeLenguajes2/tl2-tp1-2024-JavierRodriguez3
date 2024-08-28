namespace Cadetes;
using Pedidos;

public class Cadete{


    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listaPedido;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListaPedido { get => listaPedido; set => listaPedido = value; }

    public Cadete(int id, string nombre, string direccion, string telefono){
        Id = Id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        this.listaPedido = new List<Pedido>();
    }

    public void AgregarPedido(Pedido pedido){
        ListaPedido.Add(pedido);
    }

    public void EliminarPedido(Pedido pedido){
        ListaPedido.Remove(pedido);
    }

    public int JornalACobrar(){
        int jornal = ListaPedido.Count * 1400;
        return jornal;
    }
}