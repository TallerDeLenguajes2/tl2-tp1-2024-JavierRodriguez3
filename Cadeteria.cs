namespace Cadeterias;
using Cadetes;
using Pedidos;


public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listaCadete;
    Random random = new Random();

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadete { get => listaCadete; set => listaCadete = value; }

    public Cadeteria(){
        this.listaCadete = new List<Cadete>();
    }

    public void ContratarCadete(Cadete cadete){
        this.listaCadete.Add(cadete);
    }

    public void DespedirCadete(Cadete cadete){
        this.listaCadete.Remove(cadete);
    }

    public void AsignarPedido(Pedido pedido){
        if(ListaCadete.Count == 0){
            Console.WriteLine("No hay cadetes para asignar el pedido");
            return;
        }

    Cadete cadete = ListaCadete[random.Next(ListaCadete.Count)];

    cadete.AgregarPedido(pedido);

    Console.WriteLine($"El pedido fue asignado al cadete {cadete.Nombre}");

    }

    public void ReasignarPedido(Pedido pedido, Cadete Ncadete){
        foreach(var cadete in ListaCadete){
            if (cadete.ListaPedido.Contains(pedido)){
                cadete.EliminarPedido(pedido);
            }
            else{
                Console.WriteLine("El pedido no estaba asignado");
            }
        }
        Ncadete.AgregarPedido(pedido);
        Console.WriteLine($"El pedido fue reasigando al cadete {Ncadete.Nombre}");
    }

}