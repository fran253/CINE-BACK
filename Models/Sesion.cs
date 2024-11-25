namespace Models;

public class Sesion
{
    public int IdSesion { get; set; }
    public Pelicula Pelicula { get; set; }
    public Sala Sala { get; set; } // Sala puede ser eliminada si los horarios tienen sala asignada
    public Horario Horario { get; set; } // Lista de horarios
    public List<Asiento> AsientosDisponibles { get; set; }

    public Sesion(int idsesion, Pelicula pelicula, Horario horario)
{
    IdSesion = idsesion;
    Pelicula = pelicula;
    Horario = horario;

    if (Horario.Sala == null)
    {
        throw new NullReferenceException("La propiedad Sala del objeto Horario no está inicializada.");
    }

    // Crear los asientos según la capacidad de la sala
    AsientosDisponibles = new List<Asiento>();
    for (int i = 1; i <= Horario.Sala.Capacidad; i++)
    {
        AsientosDisponibles.Add(new Asiento(i, i, false));
    }
}
}
