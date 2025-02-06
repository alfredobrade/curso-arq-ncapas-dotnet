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
        // GET: api/<PedidoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PedidoController>
        [HttpPost]
        public void Post([FromBody] Pedido nuevoPedido)
        {
            var fechaHora = System.DateTime.Now;
            var db = new HardcodedDB();

            var cliente = db.Clientes.FirstOrDefault(a => a.ClienteID == nuevoPedido.ClienteID);
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
                var pedido = new Pedido
                {
                    //PedidoID = 0,
                    FechaHora = fechaHora,
                    ClienteID = cliente.ClienteID,
                    ProductosString = listaProductos.ToString()
                };

            }
            //Save pedido
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
        }
    }
}
