¿Cuál de estas relaciones considera que se realiza por composición y cuál por
agregación?
- El cliente y el pedido estan formados mediante compisicion. Mientas que el cadete y el pedido estan relacionados mediante agregacion.

¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
- Para cadeteria: ContratarCadete(); DespedirCadete(); AsignarPedido(); ReasignarPedido(); 
- Para cadete: AgregarPedido(); EliminarPedido(); 

Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos,
propiedades y métodos deberían ser públicos y cuáles privados

- 

¿Cómo diseñaría los constructores de cada una de las clases?
- public Pedidos(string nombre, string direccion, int telefono, string referenciaDireccion)
    {
        this.cliente = new Clientes(){
            Nombre = nombre, 
            Direccion = direccion, 
            Telefono = telefono, 
            ReferenciaDireccion = referenciaDireccion
        };
    }   Ejepmlo de como diseño el constructor

¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
- Si. Por ejemplo: que el cliente genere un pedido y lo envie directo a la cadeteria, luego, la cadeteria asignaria al cadete su pedido.
