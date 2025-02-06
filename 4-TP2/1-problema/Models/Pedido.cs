namespace app_pedidos.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public DateTime FechaHora { get; set; }
        //public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        //public string ProductosString { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
