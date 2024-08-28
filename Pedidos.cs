namespace Pedidos;
using Clientes;
public enum Estado{
    Pendiente,
    Entregado
}
public class Pedido{
    private int numPedido;
    private string observaciones;
    private Estado estado;
    private Cliente cliente;


    public int NumPedido { get => numPedido; set => numPedido = value; }
    public string Observaciones { get => observaciones; set => observaciones = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }

    public Pedido(int numPedido, string observaciones, Cliente cliente, Estado estado){
        NumPedido = numPedido;
        Observaciones = observaciones;
        Estado = estado;
        Cliente = cliente;
    }
    
    public void VerDireccionCliente(Cliente cliente){
        Console.WriteLine($"La direccion del cliente es {cliente.Direccion}");
    }

    public void VerDatosCliente(Cliente Cliente){
        Console.WriteLine($"El nombre del cliente es: {cliente.Nombre}\nEl telefono del cliente es: {cliente.Telefono}\nLa referencia de la direccion del cliente es: {cliente.ReferenciaDireccion}");
    }

    


    }