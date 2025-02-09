using app_pedidos.DataBase;
using app_pedidos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private static HardcodedDB db = new HardcodedDB();

        // GET: api/<PedidoController>
        [HttpGet]
        public IEnumerable<Pedido> Get()
        {
            var pedidos = db.Pedidos.ToList();
            // foreach de productos
            return pedidos;
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public Pedido Get(int id)
        {
            var pedido = db.Pedidos.FirstOrDefault(a => a.PedidoID == id);

            return pedido;
        }

        // POST api/<PedidoController>
        [HttpPost]
        public void Post([FromBody] Pedido nuevoPedido)
        {
            var fechaHora = System.DateTime.Now;

            var cliente = db.Clientes.FirstOrDefault(a => a.ClienteID == nuevoPedido.Cliente.ClienteID);
            var listaProductos = new List<string>();

            foreach (var item in nuevoPedido.Productos)
            {
                var producto = db.Productos.FirstOrDefault(a => a.ProductoID == item.ProductoID);
                if (producto != null)
                {
                    listaProductos.Add(producto.Nombre);
                }
            }
            if (listaProductos.Count > 0)
            {
                var pedidoID = db.Pedidos.Count + 1;

                var pedido = new Pedido
                {
                    PedidoID = pedidoID,
                    FechaHora = fechaHora,
                    Cliente = cliente,
                    Productos = nuevoPedido.Productos,
                    //ProductosString = listaProductos.ToString()
                };

            }
            //Save pedido
            db.Pedidos.Add(nuevoPedido);
            // hacer una pequeña introduccion de las formas de guardar la info compuesta
            // puede ser en JSON, en tablas relacionales o un archivo.


        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pedido = db.Pedidos.FirstOrDefault(a => a.PedidoID == id);
            db.Pedidos.Remove(pedido);
        }
    }
}
