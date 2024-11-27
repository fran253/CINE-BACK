using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers;

[ApiController]
[Route("CinemaParaiso/[controller]")]
public class AsientoController : ControllerBase
{
    private static List<Asiento> Asientos = new List<Asiento>();

    static AsientoController()
    {
        if (!Asientos.Any())
        {
            for (int i = 1; i <= 50; i++) // Suponiendo 50 asientos
            {
                Asientos.Add(new Asiento(i, i, false)); // Inicialmente todos los asientos están libres
            }
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Asiento>> GetAll()
    {
        return Ok(Asientos);
    }

    [HttpPost("SaveSeats")]
    public ActionResult SaveSeats([FromBody] List<int> pendingSeats)
    {
        foreach (var idAsiento in pendingSeats)
        {
            var asiento = Asientos.FirstOrDefault(a => a.IdAsiento == idAsiento);
            if (asiento != null)
            {
                asiento.Estado = true; // Marcar el asiento como ocupado
            }
        }
        return Ok(new { message = "Asientos confirmados correctamente." });
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

