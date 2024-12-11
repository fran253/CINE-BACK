using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class HorarioController : ControllerBase
    {
        public static List<Horario> horarios = new List<Horario>();

        public HorarioController()
        {
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

            // Obtener las películas desde PeliculaController
            var peliculas = PeliculaController.peliculas;

            // Validar que las salas y películas estén inicializadas
            if (salas == null || !salas.Any())
                throw new InvalidOperationException("Las salas no están inicializadas.");

            if (peliculas == null || !peliculas.Any())
                throw new InvalidOperationException("Las películas no están inicializadas.");

            horarios.Clear();
            int idHorario = 1;

            // Asignar 5 horarios por cada película
            foreach (var pelicula in peliculas)
            {
                for (int i = 0; i < 4; i++) // Crear 5 horarios por película
                {
                    // Rotar entre las salas disponibles (si hay menos salas que horarios, volver a empezar)
                    var sala = salas[i % salas.Count];

                    // Crear horarios escalonados para cada película
                    var fechaInicio = new DateTime(2024, 12, 4, 10 + (i * 2), 0, 0); 


                    horarios.Add(new Horario(
                        idHorario++,
                        fechaInicio,
                        fechaInicio.AddMinutes(pelicula.Duracion),
                        pelicula,
                        sala
                    ));
                }
            }
        }

        public static List<Horario> GetHorario()
        {
            return horarios;
        }
    }
}
