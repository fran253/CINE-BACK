using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class SesionController : ControllerBase
    {
        private static List<Sesion> sesiones = new List<Sesion>();

        public SesionController()
        {
            if (!sesiones.Any())
            {
                InicializarDatos();
            }
        }

        // Obtener todas las sesiones
        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetAll()
        {
            return Ok(sesiones);
        }

        // Obtener sesión por ID
        [HttpGet("{id}")]
        public ActionResult<object> GetById(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);
            if (sesion == null)
                return NotFound(new { Message = "No se encontró la sesión especificada." });

            return Ok(new
            {
                sesion.IdSesion,
                Pelicula = new
                {
                    sesion.Pelicula.IdPelicula,
                    sesion.Pelicula.Nombre,
                    sesion.Pelicula.Imagen,
                    sesion.Pelicula.Director,
                    sesion.Pelicula.Duracion,
                    sesion.Pelicula.Actores,
                    sesion.Pelicula.EdadMinima,
                    sesion.Pelicula.FechaEstreno,
                    sesion.Pelicula.Descripcion,
                    sesion.Pelicula.IdCategoriaPelicula,
                    sesion.Pelicula.NombreCategoria,
                    sesion.Pelicula.TrailerUrl,
                            },
                Horario = new
                {
                    sesion.Horario.IdHorario,
                    hora = sesion.Horario.FechaInicio,
                    Sala = new
                    {
                        sesion.Horario.Sala.IdSala,
                        sesion.Horario.Sala.Capacidad,
                        sesion.Horario.Sala.NombreSala,
                        sesion.Horario.Sala.PrecioAsiento
                    }
                },
                AsientosDisponibles = sesion.AsientosDisponibles.Select(a => new
                {
                    a.IdAsiento,
                    a.NumAsiento,
                    a.Libre // true = ocupado, false = libre
                })
            });
        }


        // Obtener sesiones por ID de película
        [HttpGet("Pelicula/{peliculaId}")]
        public ActionResult<IEnumerable<object>> GetByPeliculaId(int peliculaId)
        {
            var sesionesFiltradas = sesiones
                .Where(sesion => sesion.Pelicula.IdPelicula == peliculaId)
                .Select(sesion => new
                {
                    sesion.IdSesion,
                    Pelicula = new
                    {
                        sesion.Pelicula.IdPelicula,
                        sesion.Pelicula.Nombre,
                        sesion.Pelicula.Imagen,
                        sesion.Pelicula.Director,
                        sesion.Pelicula.Duracion,
                        sesion.Pelicula.Actores,
                        sesion.Pelicula.EdadMinima,
                        sesion.Pelicula.FechaEstreno,
                        sesion.Pelicula.Descripcion,
                        sesion.Pelicula.IdCategoriaPelicula,
                        sesion.Pelicula.NombreCategoria,
                        sesion.Pelicula.TrailerUrl
                    },
                    Horario = new
                    {
                        sesion.Horario.IdHorario,
                        sesion.Horario.FechaInicio,
                        sesion.Horario.FechaFin,

                        Sala = new
                        {
                            sesion.Horario.Sala.IdSala,
                            sesion.Horario.Sala.Capacidad,
                            sesion.Horario.Sala.NombreSala,
                            sesion.Horario.Sala.PrecioAsiento
                        }
                    }
                })
                .ToList();

            if (!sesionesFiltradas.Any())
                return NotFound(new { Message = "No se encontraron sesiones para esta película." });

            return Ok(sesionesFiltradas);
        }

        [HttpGet("{id}/Asientos")]
        public ActionResult<IEnumerable<object>> GetAsientosBySesion(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);

            if (sesion == null)
            {
                return NotFound(new { Message = "No se encontró la sesión especificada." });
            }

            // Retornar los asientos disponibles
            var asientos = sesion.AsientosDisponibles.Select(asiento => new
            {
                asiento.IdAsiento,
                asiento.NumAsiento,
                Estado = asiento.Libre ? "Ocupado" : "Libre" // Formatear el estado
            });

            return Ok(asientos);
        }

        
    [HttpPut("{idSesion}/Asientos")]
    public ActionResult UpdateAsientos(int idSesion, [FromBody] List<int> idsAsientos)
    {
        var sesion = sesiones.FirstOrDefault(s => s.IdSesion == idSesion);
        foreach (var idAsiento in idsAsientos)
        {
            var asiento = sesion.AsientosDisponibles.FirstOrDefault(a => a.IdAsiento == idAsiento);
                asiento.Libre = false; // cambiar estado a ocupado
        }

        return Ok(new { Message = "Asientos actualizados correctamente." });
    }


        // Inicializar sesiones
        public static void InicializarDatos()
        {
            int idSesion = 1;
            var horarios = HorarioController.horarios;

            sesiones.Clear();

            foreach (var horario in horarios)
            {
                var sesion = new Sesion(
                    idsesion: idSesion++,
                    pelicula: horario.Pelicula,
                    horario: horario);
                sesion.InicializarAsientos();    
                sesiones.Add(sesion);
                
                
            }
        }
    }
}