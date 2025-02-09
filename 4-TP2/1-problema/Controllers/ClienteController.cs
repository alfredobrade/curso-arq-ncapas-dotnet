using app_pedidos.DataBase;
using app_pedidos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private static HardcodedDB db = new HardcodedDB();

        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            
            return db.Clientes;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var cliente = db.Clientes.FirstOrDefault(a => a.ClienteID == id);
            return cliente;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var cliente = new Cliente
            {
                ClienteID = db.Clientes.Count + 1,
                Nombre = value
            };
            db.Clientes.Add(cliente);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cliente = db.Clientes.FirstOrDefault(a => a.ClienteID == id);
            if (cliente != null)
            {
                db.Clientes.Remove(cliente);
            }
        }
    }
}
