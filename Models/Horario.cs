namespace Models;

public class Horario
{
    public int IdHorario { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public Pelicula Pelicula {get; set;}

    public Sala Sala { get; set; }

    public Horario(int idHorario, DateTime fechaInicio, DateTime fechaFin, Pelicula pelicula, Sala sala)
    {
        IdHorario = idHorario;
        Pelicula = pelicula;
        FechaInicio = fechaInicio;
        FechaFin = fechaInicio.AddMinutes(Pelicula.Duracion);
        Sala = sala;
    }
}
