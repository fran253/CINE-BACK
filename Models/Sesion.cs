namespace Models;

public class Sesion
{
    public int IdSesion { get; set; }
    public Pelicula Pelicula { get; set; }
    public Horario Horario { get; set; } // Horario asociado a la sesión
    public List<Asiento> AsientosDisponibles { get; set; } = new List<Asiento>();

    public Sesion(int idsesion, Pelicula pelicula, Horario horario)
    {
        IdSesion = idsesion;
        Pelicula = pelicula;
        Horario = horario;

        if (Horario?.Sala == null)
        {
            throw new NullReferenceException("La propiedad Sala del objeto Horario no está inicializada.");
        }

        // Inicializar los asientos disponibles según la capacidad de la sala
    }

    public void InicializarAsientos()
    {
        for (int i = 1; i <= Horario.Sala.Capacidad; i++)
        {
            Asiento nuevoAsiento = new Asiento(i, i, false);
            AsientosDisponibles.Add(nuevoAsiento);
        }
    }
}
