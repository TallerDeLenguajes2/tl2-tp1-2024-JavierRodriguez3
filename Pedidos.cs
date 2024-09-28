namespace Pedidos;

using Cadetes;
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
    private Cadete cadete;


    public int NumPedido { get => numPedido; set => numPedido = value; }
    public string Observaciones { get => observaciones; set => observaciones = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }
    

    public Pedido(int numPedido, string observaciones, Cliente cliente, Estado estado, Cadete cadete){
        NumPedido = numPedido;
        Observaciones = observaciones;
        Estado = estado;
        Cliente = cliente;
        Cadete = cadete;
    }
    
    public string  VerDireccionCliente(Cliente cliente){
        
        return cliente.Direccion;
    }

    public string VerDatosCliente(Cliente cliente){
        
        return cliente.Nombre+", "+cliente.Telefono+", "+cliente.ReferenciaDireccion;
    }

    


    }