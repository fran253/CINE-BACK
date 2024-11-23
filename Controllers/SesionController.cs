using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class SesionController : ControllerBase
    {
        private static List<Sesion> sesiones = new List<Sesion>();

        //Funcion para obtener todas las sesiones
        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetAll()
        {
            return Ok(sesiones);
        }

        //Filtrado por el id de la pelicula
        //este fitlrado pilla el id de la sesion la pelicula con todos sus atributos y todos los horarios que tendrá
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
                        sesion.Pelicula.IdCategoriaPelicula
                    },
                    Horarios = sesion.Horarios.Select(horario => new 
                    {
                        horario.IdHorario,
                        horario.Hora,
                        Sala = new 
                        {
                            horario.Sala.IdSala,
                            horario.Sala.Capacidad,
                            horario.Sala.NombreSala
                        }
                    })
                })
                .ToList();

            //Si no hay resultados da error
            if (!sesionesFiltradas.Any())
                return NotFound();

            return Ok(sesionesFiltradas);
        }

        // Carga los asientos de el horario especifico
        //el horario tiene sala como atributo, ya que lo que elige el usuario es el horario, la sala le viene por defecto
        [HttpGet("Pelicula/{peliculaId}/Sesion/Horario/{horarioId}/Asientos")]
        public ActionResult<IEnumerable<object>> GetAsientosByHorario(int peliculaId, int horarioId)
        {
            // Verificar que la película existe
            var sesion = sesiones.FirstOrDefault(s => s.Pelicula.IdPelicula == peliculaId);

            if (sesion == null)
                return NotFound(new { Message = "No se encontró la película especificada." });

            // Verificar que el horario pertenece a esa película
            var horario = sesion.Horarios.FirstOrDefault(h => h.IdHorario == horarioId);

            if (horario == null)
                return NotFound(new { Message = "No se encontró el horario especificado para esta película." });

            // Obtener los asientos de la sala asociada al horario
            var asientos = horario.Sala.AsientosDisponibles.Select(asiento => new
            {
                asiento.IdAsiento,
                asiento.NumAsiento,
                Estado = asiento.Estado ? "Libre" : "Ocupado"
            });

            return Ok(asientos);
        }
    

    public static void InicializarDatos()
    {
        int idSesion = 1;

        // Llamar listas de películas y horarios desde los Controllers
        var peliculas = PeliculaController.peliculas;

        var horarios = HorarioController.horarios;

        // Para errores
        if (peliculas == null || !peliculas.Any())
            throw new InvalidOperationException("Las películas no están inicializadas.");
        if (horarios == null || !horarios.Any())
            throw new InvalidOperationException("Los horarios no están inicializados.");

        // Asociar horarios compartidos a las películas
        foreach (var pelicula in peliculas)
        {
            // Asignar algunos horarios globales a cada película (puedes ajustar cuántos horarios quieres asignar)
            var horariosAsignados = horarios.Take(5).ToList(); // Asignamos los primeros 3 horarios como ejemplo

            // Crear una sesión para la película
            sesiones.Add(new Sesion(
                idsesion: idSesion++,
                pelicula: pelicula,
                horarios: horariosAsignados
            ));
        }
    }



}
}
