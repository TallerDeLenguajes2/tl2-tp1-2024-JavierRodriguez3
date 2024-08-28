using Cadeterias;

Cadeteria miCadeteria = new Cadeteria();

miCadeteria = LecturaCsv.TraerDatosDeCsv(@"D:\AAA UNIVERSIDAD\3er año 2do cuatrimestre\Taller de lenguaje 2\Repotaller\tl2-tp1-2024-JavierRodriguez3\CSV\Cadetes.csv", @"D:\AAA UNIVERSIDAD\3er año 2do cuatrimestre\Taller de lenguaje 2\Repotaller\tl2-tp1-2024-JavierRodriguez3\CSV\Cadeteria.csv", miCadeteria);

Console.WriteLine($"{miCadeteria.Nombre}");


foreach(var x in miCadeteria.ListaCadete){
        Console.WriteLine("Informacion de Cadete\n");
        Console.WriteLine("ID: " + x.Id);
        Console.WriteLine("Nombre: " + x.Nombre);
        Console.WriteLine("Domicilio: " + x.Direccion);
        Console.WriteLine("Telefono: " + x.Telefono);
        foreach(var y in x.ListaPedido){
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
        }

}
