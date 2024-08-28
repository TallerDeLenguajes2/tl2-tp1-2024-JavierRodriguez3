using Cadeterias;
using Cadetes;
using Pedidos;

Cadeteria miCadeteria = new Cadeteria();
List<Pedido> pedidosSinAsignar = new List<Pedido>();
List<Pedido> pedidosAsignados = new List<Pedido>();

miCadeteria = LecturaCsv.TraerDatosDeCsv(@"C:\AAAFacultad\Taller2\tl2-tp1-2024-JavierRodriguez3\CSV\Cadetes.csv", @"C:\AAAFacultad\Taller2\tl2-tp1-2024-JavierRodriguez3\CSV\Cadeteria.csv", miCadeteria);

Console.WriteLine($"{miCadeteria.Nombre}");

foreach (var x in miCadeteria.ListaCadete)
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
}

int opcion;
do
{
    Console.WriteLine("1. Dar de alta un pedido");
    Console.WriteLine("2. Asignar un pedido");
    Console.WriteLine("3. Cambiar de estado un pedido");
    Console.WriteLine("4. Reasginar el pedido a otro cadete");
    Console.WriteLine("5. Salir"); // Cambié el texto de opción "4" a "5" para salir
    opcion = int.Parse(Console.ReadLine());

} while (opcion < 1 || opcion > 5); // Cambié a 1 para que las opciones sean válidas desde 1 a 5

switch (opcion)
{
    case 1:
        Pedido pedidoCargado = miCadeteria.DarDeAltaPedido();
        pedidosSinAsignar.Add(pedidoCargado);
        break;
    case 2:
        if (pedidosSinAsignar.Count > 0) // Cambié null check a Count check para verificar si hay elementos
        {
            miCadeteria.AsignarPedido(pedidosSinAsignar[0]);
            pedidosSinAsignar.RemoveAt(0);
            Console.WriteLine("Pedido asignado con exito");
        }
        else
        {
            Console.WriteLine("Sin pedidos para asignar");
        }
        break;
    case 3:
        Console.WriteLine("Ingresar el numero del pedido a  buscar (42, 43, 44)");
        int nPed = int.Parse(Console.ReadLine());

        Pedido pedidoEncontrado = null; // Inicializo la variable

        // Uso de LINQ fuera del bucle
        pedidoEncontrado = pedidosAsignados.FirstOrDefault(c => c.NumPedido == nPed);
        if (pedidoEncontrado != null) // Verifica si se encontró el pedido antes de cambiar su estado
        {
            if (pedidoEncontrado.Estado == Estado.Entregado)
            {
                pedidoEncontrado.Estado = Estado.Pendiente;
                LecturaCsv.AgregarPedidoAlCSV(@"C:\AAAFacultad\Taller2\tl2-tp1-2024-JavierRodriguez3\CSV\Cadetes.csv", pedidoEncontrado);
            }
            else
            {
                pedidoEncontrado.Estado = Estado.Entregado;
                LecturaCsv.AgregarPedidoAlCSV(@"C:\AAAFacultad\Taller2\tl2-tp1-2024-JavierRodriguez3\CSV\Cadetes.csv", pedidoEncontrado);
            }
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }
        break;
    case 4:

        Cadete cadeteEncontrado = null;
        Console.WriteLine("Ingresar numero de pedido a cambiar de cadete");
        int nPedN = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingresar ID del cadete a entregar pedido");
        int ID = int.Parse(Console.ReadLine());

        Pedido pedidoEncontradoCambiar = null; 
        
        // Uso de LINQ fuera del bucle
        pedidoEncontradoCambiar = pedidosAsignados.FirstOrDefault(c => c.NumPedido == nPedN);
        cadeteEncontrado = miCadeteria.ListaCadete.FirstOrDefault(c => c.Id == ID);

        Console.WriteLine($"{cadeteEncontrado.Nombre} nombre del cadete encontrado");

        miCadeteria.ReasignarPedido(pedidoEncontradoCambiar, cadeteEncontrado, miCadeteria);

    break;
}
