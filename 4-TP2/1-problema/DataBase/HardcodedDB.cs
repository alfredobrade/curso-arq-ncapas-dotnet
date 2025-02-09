using app_pedidos.Models;

namespace app_pedidos.DataBase
{
    public class HardcodedDB
    {


        public List<Cliente> Clientes { get; set; } = new List<Cliente>
        {
            new Cliente
            {
                ClienteID = 1,
                Nombre = "Juan"
            },
            new Cliente
            {
                ClienteID = 2,
                Nombre = "Belen"
            }
        };

        public List<Producto> Productos = new List<Producto>
        {
            new Producto
            {
                ProductoID = 1,
                Nombre = "Martillo",
                Precio = 10.6M
            },

        };

        public List<Pedido> Pedidos = new List<Pedido>
        {
            new Pedido
            {
                PedidoID = 1,
                FechaHora = DateTime.Now,
                Cliente = new Cliente(),
                Productos = new List<Producto>
                {
                    new Producto(),
                }
            }
        };
    }
}
