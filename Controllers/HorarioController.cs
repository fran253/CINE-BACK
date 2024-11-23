using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class HorarioController : ControllerBase
    {
        public static List<Horario> horarios = new List<Horario>();

        public HorarioController(){
        if (horarios.Count == 0)
        {
            InicializarHorarios();
        }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Horario>> GetAll()
        {
            return Ok(horarios);
        }

        [HttpGet("{id}")]
        public ActionResult<Horario> GetById(int id)
        {
            var horario = horarios.FirstOrDefault(s => s.IdHorario == id);
            if (horario == null)
                return NotFound();
            return Ok(horario);
        }
        
        public static void InicializarHorarios(){
            //Salas A
            horarios.Add(new Horario(1,new DateTime(2024, 11, 6, 18, 0, 0),new Sala(1, 100, "A-1")));
            horarios.Add(new Horario(2,new DateTime(2024, 11, 6, 20, 30, 0), new Sala(1, 100, "A-2")));
            horarios.Add(new Horario(3, new DateTime(2024, 11, 6, 14, 30, 0), new Sala(1, 100, "A-3")));
            //Salas B
            horarios.Add(new Horario(4, new DateTime(2024, 11, 7, 10, 0, 0), new Sala(4, 100, "B-1")));
            horarios.Add(new Horario(5, new DateTime(2024, 11, 7, 12, 30, 0), new Sala(5, 80, "B-2")));
            horarios.Add(new Horario(6, new DateTime(2024, 11, 7, 15, 0, 0), new Sala(6, 80, "B-3")));
            //Salas C
            horarios.Add(new Horario(7, new DateTime(2024, 11, 8, 10, 0, 0), new Sala(7, 100, "C-1")));
            horarios.Add(new Horario(8, new DateTime(2024, 11, 8, 12, 30, 0), new Sala(8, 80, "C-2")));
            horarios.Add(new Horario(9, new DateTime(2024, 11, 8, 15, 0, 0), new Sala(9, 80, "C-3")));


            


                    
        }

        public static List<Horario> GetHorario(){
        return horarios;
        }


    }
}
