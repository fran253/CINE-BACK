using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class AsientoController : ControllerBase
    {
        private static List<Asiento> Asientos = new List<Asiento>();

        [HttpGet]
        public ActionResult<IEnumerable<Asiento>> GetAll()
        {
            return Ok(Asientos);
        }

        [HttpGet("{id}")]
        public ActionResult<Asiento> GetById(int id)
        {
            var asiento = Asientos.FirstOrDefault(a => a.IdAsiento == id);
            if (asiento == null)
                return NotFound();
            return Ok(asiento);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Asiento asiento)
        {
            Asientos.Add(asiento);
            return CreatedAtAction(nameof(GetById), new { id = asiento.IdAsiento }, asiento);
        }

///////////////////////////////////////////////////////////////////////////////////////////De momento no se necesita el UPDATE
        // [HttpPut("{id}")]
        // public ActionResult Update(int id, [FromBody] Asiento updatedAsiento)
        // {
        //     var asiento = Asientos.FirstOrDefault(a => a.IdAsiento == id);
        //     if (asiento == null)
        //         return NotFound();

        //     asiento.Estado = updatedAsiento.Estado;
        //     return NoContent();
        // }

///////////////////////////////////////////////////////////////////////////////////////////De momento no se necesita el DELETE
        // [HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     var asiento = Asientos.FirstOrDefault(a => a.IdAsiento == id);
        //     if (asiento == null)
        //         return NotFound();

        //     Asientos.Remove(asiento);
        //     return NoContent();
        // }
        public static void InicializarDatos()
        {
            
        }

    }
}
