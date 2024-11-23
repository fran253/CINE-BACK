using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class EntradaController : ControllerBase
    {
        private static List<Entrada> Entradas = new List<Entrada>();

        [HttpGet]
        public ActionResult<IEnumerable<Entrada>> GetAll()
        {
            return Ok(Entradas);
        }

        [HttpGet("{id}")]
        public ActionResult<Entrada> GetById(int id)
        {
            var entrada = Entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
                return NotFound();
            return Ok(entrada);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Entrada entrada)
        {
            Entradas.Add(entrada);
            return CreatedAtAction(nameof(GetById), new { id = entrada.Id }, entrada);
        } 


///////////////////////////////////////////////////////////////////////////////////////////De momento no se necesita el UPDATE
        // [HttpPut("{id}")]
        // public ActionResult Update(int id, [FromBody] Entrada updatedEntrada)
        // {
        //     var entrada = Entradas.FirstOrDefault(e => e.Id == id);
        //     if (entrada == null)
        //         return NotFound();

        //     entrada.Precio = updatedEntrada.Precio;
        //     return NoContent();
        // }

///////////////////////////////////////////////////////////////////////////////////////////De momento no se necesita el DELETE
        // [HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     var entrada = Entradas.FirstOrDefault(e => e.Id == id);
        //     if (entrada == null)
        //         return NotFound();

        //     Entradas.Remove(entrada);
        //     return NoContent();
        // }
        public static void InicializarDatos()
        {
            
        }
    }
}
