using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class SesionController : ControllerBase
    {
        private static List<Sesion> sesiones = new List<Sesion>();
        private static int ultimoIdSesion = 0; 


        //Funcion para obtener todas las sesiones
        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetAll()
        {
            return Ok(sesiones);
        }

        //Filtrado para obtener la sesion por id de la misma
        [HttpGet("{id}")]
        public ActionResult<Sesion> GetById(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.IdSesion == id);
            if (sesion == null)
                return NotFound();
            return Ok(sesion);
        }

       [HttpGet("PeliculaSesion/{idPelicula}")]
        public ActionResult<List<Sesion>> GetSesionesByIdPelicula(int idPelicula)
        {
            var peliculasFiltradas = sesiones.Where(sesion => sesion.Pelicula.IdPelicula == idPelicula).ToList();

            return Ok(peliculasFiltradas);
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
        int idHorario = 1; 
        //creamos "peliculas" y le asignamos lista para todas las peliculas 
        var peliculas = new List<Pelicula>
        {
            new Pelicula(1, "RED ONE", "../imgs/RedOne.jpg", "Jake Kasdan", 148, "Nick Kroll, Dwayne Johnson...", "+7", new DateTime(2024, 11, 6), "Descripción RED ONE", 1),
            new Pelicula(2, "VENOM 3", "../imgs/venom3.jpg", "Kelly Marcel", 138, "Rhys Ifans, Tom Hardy...", "+12", new DateTime(2024, 10, 25), "Descripción VENOM 3", 2),
            new Pelicula(3, "GLADIATOR II", "../imgs/Gladiator2.jpg", "Ridley Scott", 138, "Paul Mescal, Denzel Washington...", "+16", new DateTime(2024, 11, 15), "Descripción GLADIATOR II", 3),
            new Pelicula(4, "TERRIFIER 3", "../imgs/Terrifier3.jpeg", "Chris Sanders", 100, "Bill Nighy, Lupita Nyong'o...", "TP", new DateTime(2024, 10, 11), "Descripción TERRIFIER 3", 5),
            new Pelicula(5, "DUNE: PARTE DOS", "../imgs/Dune2.jpg", "Denis Villeneuve", 155, "Timothée Chalamet, Zendaya...", "+12", new DateTime(2024, 11, 3), "Descripción DUNE 2", 2),
            new Pelicula(6, "THE BATMAN: CAPÍTULO DOS", "../imgs/TheBatman2.jpeg", "Matt Reeves", 185, "Robert Pattinson...", "+16", new DateTime(2025, 3, 15), "Descripción BATMAN 2", 3),
            new Pelicula(7, "AVATAR 3", "../imgs/Avatar3.jpg", "James Cameron", 190, "Sam Worthington...", "TP", new DateTime(2024, 12, 20), "Descripción AVATAR 3", 1),
            new Pelicula(8, "SPIDER-MAN: MÁS ALLÁ DEL MULTIVERSO", "../imgs/SpiderBeyond.jpg", "Joaquim Dos Santos", 130, "Shameik Moore...", "+7", new DateTime(2025, 5, 10), "Descripción SPIDER-MAN", 2)
        };

        //creamos "salas" y le asignamos lista para todas las salas 
        var salas = new List<Sala>
        {
            new Sala(1, 100, "A-1"),
            new Sala(2, 80, "A-2"),
            new Sala(3, 80, "A-3"),
            new Sala(4, 100, "B-1"),
            new Sala(5, 80, "B-2"),
            new Sala(6, 80, "B-3"),
            new Sala(7, 100, "C-1"),
            new Sala(8, 80, "C-2"),
            new Sala(9, 80, "C-3")
        };

        //si la pelicula esta dentro de la lista creada anteriormente...
        foreach (var pelicula in peliculas)
        {
            // Creamos horarios para dicha pelicula, cada horario sera diferente, eso lo hacemos con contadores
            var horarios = new List<Horario>
            {
                new Horario(idHorario++, new DateTime(2024, 11, 6, 16, 0, 0), salas[(pelicula.IdPelicula - 1) % salas.Count]),
                new Horario(idHorario++, new DateTime(2024, 11, 6, 18, 30, 0), salas[(pelicula.IdPelicula + 1) % salas.Count]),
                new Horario(idHorario++, new DateTime(2024, 11, 6, 20, 0, 0), salas[(pelicula.IdPelicula + 2) % salas.Count])
            };

            // Creamos la sesion el id sesion es un contador y sera distinto cada vez, la pelicula que este asociada y los horarios de la pelicula
            sesiones.Add(new Sesion(
                idsesion: idSesion++,
                pelicula: pelicula,
                horarios: horarios
            ));
        }
    }

}
}
