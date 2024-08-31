namespace Cadeterias;
using Cadetes;
using Clientes;
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

        public void ReasignarPedido(Pedido pedido){
            Cadete cadete1 = null;

            foreach (var cadete in listaCadete){
                if(cadete.ListaPedido.Contains(pedido)){
                    cadete1 = cadete;
                }
            }

            Cadete nCadete = ListaCadete[random.Next(ListaCadete.Count)];
            Console.WriteLine($"{nCadete.Nombre} nombre del nuevo cadete");

            nCadete.AgregarPedido(pedido);
            Console.WriteLine($"El pedido fue reasigando al cadete {nCadete.Nombre}");

            Console.WriteLine($"{cadete1.Nombre} nombre del cadete viejo");
            cadete1.EliminarPedido(pedido);
        }

    public Pedido DarDeAltaPedido(){
        Console.WriteLine("Ingresar el numero del pedido");
        int numPed = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingresar las observaciones del pedido");
        string obs = Console.ReadLine();

        Console.WriteLine("Ingresar nombre del clinete");
        string nombreClie = Console.ReadLine();

        Console.WriteLine("Ingresar direccion del cliente");
        string direClie = Console.ReadLine();

        Console.WriteLine("Ingresar telefono del cliente");
        string telClient = Console.ReadLine();

        Console.WriteLine("Ingresar referencias de la direccion del cliente");
        string direRefClie = Console.ReadLine();

        var cliente = new Cliente(nombreClie, direClie, telClient, direRefClie);
        return new Pedido(numPed, obs, cliente, Estado.Pendiente);
    }


}

