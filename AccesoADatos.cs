namespace datos;
using Cadeterias;
using Cadetes;
using System.Text.Json;

public abstract class AccesoADatos{
    public abstract Cadeteria CargarCadeteria(string archivo1, string archivo2, Cadeteria miCadeteria);

}

public class AccesoCSV : AccesoADatos
{
    public override Cadeteria CargarCadeteria(string archivo1, string archivo2, Cadeteria miCadeteria)
    {
        // Leer datos de la cadetería desde el archivo CSV
        using (StreamReader archivo = new StreamReader(archivo2))
        {
            string separador = ",";
            string linea;
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                miCadeteria.Nombre = fila[0];
                miCadeteria.Telefono = int.Parse(fila[1]);
            }
        }

        // Leer datos de los cadetes desde el archivo CSV
        using (StreamReader archivo = new StreamReader(archivo1))
        {
            string separador = ",";
            string linea;
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);

                // Crear o agregar pedido a la instancia de Cadete
                int idCadete = int.Parse(fila[0]);
                Cadete cadeteExistente = miCadeteria.ListaCadete.FirstOrDefault(c => c.Id == idCadete);
                Cadete nuevoCadete = new Cadete(idCadete, fila[1], fila[2], fila[3]);
                miCadeteria.ListaCadete.Add(nuevoCadete);
            }
        }

        return miCadeteria;
}
}


//para el json

public class AccesoJSON : AccesoADatos
{
    public override Cadeteria CargarCadeteria(string archivo1, string archivo2, Cadeteria miCadeteria)
    {

        try
        {
            string contenidoCadeteriaJson = File.ReadAllText(archivo2);
            miCadeteria = JsonSerializer.Deserialize<Cadeteria>(contenidoCadeteriaJson) ?? miCadeteria;

            string contenidoCadetesJson = File.ReadAllText(archivo1);
            List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(contenidoCadetesJson) ?? new List<Cadete>();

            // Asigno los cadetes a la cadetería
            miCadeteria.ListaCadete = cadetes;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al leer o deserializar los archivos JSON: {ex.Message}");
        }

        return miCadeteria;
    }
}




    /*public static void AgregarPedidoAlCSV(string rutaArchivo, Pedido pedido)
{
    List<string> lineas = new List<string>();

    // Leer todas las líneas del archivo CSV
    using (StreamReader archivo = new StreamReader(rutaArchivo))
    {
        string linea;
        while ((linea = archivo.ReadLine()) != null)
        {
            lineas.Add(linea);
        }
    }

    // Buscar y modificar la línea correspondiente al pedido
    for (int i = 0; i < lineas.Count; i++)
    {
        string[] fila = lineas[i].Split(',');
        // Actualizar solo el estado del pedido en la línea
        fila[10] = pedido.Estado.ToString();
        lineas[i] = string.Join(",", fila);
        break; // Salir del bucle después de encontrar y modificar el pedido
    }

    // Sobrescribir el archivo CSV con las líneas modificadas
    using (StreamWriter archivo = new StreamWriter(rutaArchivo, false))
    {
        foreach (string linea in lineas)
        {
            archivo.WriteLine(linea);
        }
    }
}
  //Queda como ejemplo para cargar un csv
*/
