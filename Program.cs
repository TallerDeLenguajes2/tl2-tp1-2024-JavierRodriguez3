using System.Runtime.InteropServices;
using Cadeterias;
using datos;
using Pedidos;

Cadeteria miCadeteria = new Cadeteria();
List<Pedido> pedidosSinAsignar = new List<Pedido>();
List<Pedido> pedidosAsignados = new List<Pedido>();
AccesoADatos accesoDatos;
string extension;
string carpeta;

Console.WriteLine("1. CSV");
Console.WriteLine("2. JSON");
Console.Write("\nSeleccione el tipo de acceso a datos:");
int opcion1 = int.Parse(Console.ReadLine());

switch (opcion1)
{
    case 1:
        accesoDatos = new AccesoCSV();
        extension = ".csv";
        carpeta = "CSV";
        break;
    case 2:
        accesoDatos = new AccesoJSON();
        extension = ".json";
        carpeta = "JSON";
        break;
    default:
        Console.WriteLine("Opción no válida. Se utilizará acceso CSV por defecto.");
        accesoDatos = new AccesoCSV();
        extension = ".csv";
        carpeta = "CSV";
        break;
}

miCadeteria = accesoDatos.CargarCadeteria(@$"D:\AAA UNIVERSIDAD\3er año 2do cuatrimestre\Taller de lenguaje 2\Repotaller\tl2-tp1-2024-JavierRodriguez3\{carpeta}\Cadetes{extension}", $@"D:\AAA UNIVERSIDAD\3er año 2do cuatrimestre\Taller de lenguaje 2\Repotaller\tl2-tp1-2024-JavierRodriguez3\{carpeta}\Cadeteria{extension}", miCadeteria);

Console.WriteLine($"{miCadeteria.Nombre}");

/*foreach (var x in miCadeteria.ListaCadete)
{
    Console.WriteLine("Informacion de Cadete\n");
    Console.WriteLine("ID: " + x.Id);
    Console.WriteLine("Nombre: " + x.Nombre);
    Console.WriteLine("Domicilio: " + x.Direccion);
    Console.WriteLine("Telefono: " + x.Telefono);
    foreach (var y in x.ListaPedido)
    {
        Console.WriteLine("Informacion del Pedido\n");
        Console.WriteLine("Pedido Nro: " + y.NumPedido);
        Console.WriteLine("Observacion del Pedido: " + y.Observaciones);
        Console.WriteLine("Informacion Cliente \n");
        Console.WriteLine("Nombre: " + y.Cliente.Nombre);
        Console.WriteLine("Direccion: " + y.Cliente.Direccion);
        Console.WriteLine("Telefono: " + y.Cliente.Telefono);
        Console.WriteLine("Alguna referencia para ubicar al cadete: " + y.Cliente.ReferenciaDireccion);
        Console.WriteLine("\nEstado del Pedido: " + y.Estado);
        Console.WriteLine("");
        pedidosAsignados.Add(y);
    }
}*/

int opcion;
do
{
    Console.WriteLine("1. Dar de alta un pedido");
    Console.WriteLine("2. Asignar un pedido");
    Console.WriteLine("3. Cambiar de estado un pedido");
    Console.WriteLine("4. Reasginar el pedido a otro cadete");
    Console.WriteLine("5. Leer cadetes con pedidos");
    Console.WriteLine("6. Leer Todos los cadetes");
    Console.WriteLine("7. Salir"); // Cambié el texto de opción "4" a "5" para salir
    opcion = int.Parse(Console.ReadLine());


switch (opcion)
{
    case 1:
        var pedidoCargado = miCadeteria.DarDeAltaPedido();
        miCadeteria.ListaPedido.Add(pedidoCargado);

        
        break;
    case 2:

            Console.WriteLine("Ingresar el id del pedido a asignar");
            int idPedidoRequerido1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar el id del Cadete a asignar el pedido");
            int idCadeteRequerido = int.Parse(Console.ReadLine());
            miCadeteria.AsignarPedido(idCadeteRequerido, idPedidoRequerido1);

        break;
    case 3:
        Console.WriteLine("Ingresar el numero del pedido a  buscar");
        int nPed = int.Parse(Console.ReadLine());

        Pedido pedidoEncontrado = null; // Inicializo la variable

        // Uso de LINQ fuera del bucle
        pedidoEncontrado = miCadeteria.ListaPedido.FirstOrDefault(c => c.NumPedido == nPed);
        if (pedidoEncontrado != null) // Verifica si se encontró el pedido antes de cambiar su estado
        {
            if (pedidoEncontrado.Estado == Estado.Entregado)
            {
                pedidoEncontrado.Estado = Estado.Pendiente;
                
            }
            else
            {
                pedidoEncontrado.Estado = Estado.Entregado;
                
            }
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }
        break;
    case 4:
        // Uso de LINQ fuera del bucle
        Console.WriteLine("Ingresar el id del pedido a asignar");
        int idPedidoRequerido = int.Parse(Console.ReadLine());
        Pedido pedidoACambiar = miCadeteria.ListaPedido.FirstOrDefault(x => x.NumPedido == idPedidoRequerido);
        miCadeteria.ReasignarPedido(pedidoACambiar);

    break;
    case 5:
        


        foreach (var pedido in miCadeteria.ListaPedido)
        {
            Console.WriteLine("Informacion de Cadete\n");
            Console.WriteLine("ID: " + pedido.Cadete.Id);
            Console.WriteLine("Nombre: " + pedido.Cadete.Nombre);
            Console.WriteLine("Domicilio: " + pedido.Cadete.Direccion);
            Console.WriteLine("Telefono: " + pedido.Cadete.Telefono);
            Console.WriteLine("Informacion del Pedido\n");
            Console.WriteLine("Pedido Nro: " + pedido.NumPedido);
            Console.WriteLine("Observacion del Pedido: " + pedido.Observaciones);
            Console.WriteLine("Informacion Cliente \n");
            Console.WriteLine("Nombre: " + pedido.Cliente.Nombre);
            Console.WriteLine("Direccion: " + pedido.Cliente.Direccion);
            Console.WriteLine("Telefono: " + pedido.Cliente.Telefono);
            Console.WriteLine("Alguna referencia para ubicar al cadete: " + pedido.Cliente.ReferenciaDireccion);
            Console.WriteLine("\nEstado del Pedido: " + pedido.Estado);
        }


        
    break;
    case 6:
        foreach (var x in miCadeteria.ListaCadete)
        {
            Console.WriteLine("Informacion de Cadete\n");
            Console.WriteLine("ID: " + x.Id);
            Console.WriteLine("Nombre: " + x.Nombre);
            Console.WriteLine("Domicilio: " + x.Direccion);
            Console.WriteLine("Telefono: " + x.Telefono);
        }
    break;
    default:
        Console.WriteLine("Opcion no valida");
        break;
}

} while (opcion != 7); // Cambié a 1 para que las opciones sean válidas desde 1 a 5

