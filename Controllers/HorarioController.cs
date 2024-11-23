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
        
        public static void InicializarHorarios()
        {
            // Obtener las salas desde SalaController
            var salas = SalaController.Salas;

            // Validar que las salas estén inicializadas
            if (salas == null || !salas.Any())
                throw new InvalidOperationException("Las salas no están inicializadas.");

            // Inicializar 5 horarios compartidos entre las salas
            horarios.Add(new Horario(1, new DateTime(2024, 11, 6, 10, 0, 0), salas.FirstOrDefault(s => s.IdSala == 1))); // Sala A-1
            horarios.Add(new Horario(2, new DateTime(2024, 11, 6, 12, 30, 0), salas.FirstOrDefault(s => s.IdSala == 2))); // Sala A-2
            horarios.Add(new Horario(3, new DateTime(2024, 11, 6, 15, 0, 0), salas.FirstOrDefault(s => s.IdSala == 3))); // Sala A-3
            horarios.Add(new Horario(4, new DateTime(2024, 11, 6, 17, 30, 0), salas.FirstOrDefault(s => s.IdSala == 4))); // Sala B-1
            horarios.Add(new Horario(5, new DateTime(2024, 11, 6, 20, 0, 0), salas.FirstOrDefault(s => s.IdSala == 5))); // Sala B-2
        }


        public static List<Horario> GetHorario(){
        return horarios;
        }


    }
}
