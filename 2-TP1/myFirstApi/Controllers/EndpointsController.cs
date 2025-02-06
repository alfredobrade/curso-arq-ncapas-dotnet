

using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointsController : ControllerBase
    {

        [HttpGet]
        public ActionResult ApiCheck()
        {
            return Ok("I'm alive!");
        }

        [HttpGet("saludo/{name}")]
        public ActionResult HelloPath(string name)
        {
            return Ok($"Hola {name}!");

        }

        [HttpGet("saludo")]
        public ActionResult HelloQueryStg(string name)
        {
            return Ok($"Hola {name} por query string!");

        }


        [HttpGet("suma")]
        public ActionResult Suma(int num1, int num2)
        {
            int resultado = num1 + num2;
            return Ok(resultado);
        }

        [HttpPost("suma")]
        public ActionResult SumaPost([FromBody] SumaRequest request)
        {
            int resultado = request.Num1 + request.Num2;
            return Ok(resultado);
        }


    }
}