using app_pedidos.DataBase;
using app_pedidos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private static HardcodedDB db = new HardcodedDB();

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return db.Productos;
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public Producto Get(int id)
        {

            return db.Productos.FirstOrDefault(a => a.ProductoID == id);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] Producto producto)
        {
            db.Productos.Add(producto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Producto producto)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var producto = db.Productos.FirstOrDefault(a => a.ProductoID == id);

            if (producto != null)
            {
                db.Productos.Remove(producto);
            }
        }
    }
}
