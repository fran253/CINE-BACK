// using Microsoft.AspNetCore.Mvc;
// using Models;

// namespace CineApi.Controllers
// {
//     [ApiController]
//     [Route("CinemaParaiso/[controller]")]
//     public class OperacionController : ControllerBase
//     {
//         private static List<Operacion> operaciones = new List<Operacion>();

//         [HttpGet]
//         public ActionResult<IEnumerable<Operacion>> GetAll()
//         {
//             return Ok(operaciones);
//         }


//         [HttpGet("{id}")]
//         public ActionResult<Operacion> GetById(int id)
//         {
//             var operacion = operaciones.FirstOrDefault(o => o.IdOperacion == id);
//             if (operacion == null)
//                 return NotFound();
//             return Ok(operacion);
//         }

//         [HttpGet("Sesion/{idSesion}")]
//         public ActionResult<IEnumerable<object>> GetByIdAsientosSeleccionados(int idSesion)
//         {
//             var operacionesFiltradas = operaciones
//                 .Where(operacion => operacion.Sesion.IdSesion == idSesion)
//                 .Select(operacion => new
//                 {
//                     operacion.IdOperacion,
//                     Pelicula = new
//                     {
//                         operacion.Sesion.Pelicula.Nombre,
//                         operacion.Sesion.Pelicula.Imagen,
//                         operacion.Sesion.Pelicula.Director
//                     },
//                     Horario = new
//                     {
//                         operacion.Sesion.Horario.FechaInicio,
//                         Sala = new
//                         {
//                             operacion.Sesion.Horario.Sala.NombreSala,
//                             operacion.Sesion.Horario.Sala.Capacidad
//                         }
//                     },
//                     Asiento = new
//                     {
//                         operacion.Asiento.IdAsiento,
//                         operacion.Asiento.NumAsiento,
//                         Estado = operacion.Asiento.Libre ? "Libre" : "Ocupado"
//                     }
//                 })
//                 .ToList();

//             if (!operacionesFiltradas.Any())
//                 return NotFound();

//             return Ok(operacionesFiltradas);
//         }

//         public static void InicializarDatos()
//         {
//             int IdOperacion = 1;

//             // Obtener datos de SesionController
//             var sesiones = SesionController.GetAll();

//             if (sesiones == null || !sesiones.Any())
//                 throw new InvalidOperationException("No hay sesiones disponibles.");

//             // Simular una operación inicial para probar
//             operaciones.Add(new Operacion(
//                 idoperacion: IdOperacion++,
//                 sesion: sesiones.First(), // Toma la primera sesión como ejemplo
//                 asiento: sesiones.First().Horarios.First().Sala.AsientosDisponibles.First() // Toma el primer asiento disponible
//             ));
//         }
//     }
// }
