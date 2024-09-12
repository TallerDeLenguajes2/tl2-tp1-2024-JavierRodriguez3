namespace Cadeterias;
using Cadetes;
using Clientes;
using Pedidos;


public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listaCadete;
    private List<Pedido> listaPedido;
    Random random = new Random();

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadete { get => listaCadete; set => listaCadete = value; }
    public List<Pedido> ListaPedido { get => listaPedido; set => listaPedido = value; }

    public Cadeteria(){
        this.listaCadete = new List<Cadete>();
        this.listaPedido = new List<Pedido>();
    }

    public void ContratarCadete(Cadete cadete){
        this.listaCadete.Add(cadete);
    }

    public void DespedirCadete(Cadete cadete){
        this.listaCadete.Remove(cadete);
    }

    public void AsignarPedido(int idCadete, int idPedido){
        

    var pedido = listaPedido.FirstOrDefault(x => x.NumPedido == idPedido);
    var cadete = listaCadete.FirstOrDefault(x => x.Id == idCadete);

    if(pedido != null && cadete != null){
        pedido.Cadete = cadete;

        Console.WriteLine($"El pedido {pedido.NumPedido} fue asignado al cadete {cadete.Nombre}");
    }

    }

        public void ReasignarPedido(Pedido pedidoACambiar){


            Cadete nCadete = ListaCadete[random.Next(ListaCadete.Count)];
            Console.WriteLine($"{nCadete.Nombre} nombre del nuevo cadete");
            
            //Console.WriteLine($"{pedidoACambiar.Cadete.Nombre} nombre del cadete viejo");

            pedidoACambiar.Cadete = nCadete;
            Console.WriteLine($"El pedido fue reasigando al cadete {nCadete.Nombre}");
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
        return new Pedido(numPed, obs, cliente, Estado.Pendiente, null);
    }

    public int JornalACobrar(int idCadete){
        int pedidosRealizados = listaPedido.Count(x => x.Cadete.Id == idCadete);
        return pedidosRealizados*1500;
    }
    public void AgregarPedido(Pedido pedido){
        ListaPedido.Add(pedido);
    }

    public void EliminarPedido(Pedido pedido){
        ListaPedido.Remove(pedido);
    }
}

