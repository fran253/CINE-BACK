using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class SalaController : ControllerBase
    {
        public static List<Sala> Salas = new List<Sala>();

        [HttpGet]
        public ActionResult<IEnumerable<Sala>> GetAll()
        {
            return Ok(Salas);
        }

        [HttpGet("{id}")]
        public ActionResult<Sala> GetById(int id)
        {
            var sala = Salas.FirstOrDefault(s => s.IdSala == id);
            if (sala == null)
                return NotFound();
            return Ok(sala);
        }
                public static void InicializarDatos(){
                    Salas.Add(new Sala(1, 100,"A-1"));
                    Salas.Add(new Sala(2, 80,"A-2"));
                    Salas.Add(new Sala(3, 80,"A-3"));
                    Salas.Add(new Sala(4, 100, "B-1"));
                    Salas.Add(new Sala(5, 80, "B-2"));
                    Salas.Add(new Sala(6, 80, "B-3"));
                    Salas.Add(new Sala(7, 100, "C-1"));
                    Salas.Add(new Sala(8, 80, "C-2"));
                    Salas.Add(new Sala(9, 80, "C-3"));



                }

    }
}
