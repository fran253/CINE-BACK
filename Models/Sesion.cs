namespace Models;

public class Sesion
{
    public int IdSesion { get; set; }
    public Pelicula Pelicula { get; set; }
    public Sala Sala { get; set; } // Sala puede ser eliminada si los horarios tienen sala asignada
    public List<Horario> Horarios { get; set; } // Lista de horarios
    public List<Asiento> AsientosDisponibles { get; set; }

    public Sesion(int idsesion, Pelicula pelicula, List<Horario> horarios)
    {
        IdSesion = idsesion;
        Pelicula = pelicula;
        Horarios = horarios;

        // Los asientos se basan en la capacidad de la sala del primer horario
        if (Horarios.Count > 0)
        {
            Sala = Horarios[0].Sala; // Vincula la sala del primer horario
            AsientosDisponibles = new List<Asiento>();
            for (int i = 1; i <= Sala.Capacidad; i++)
            {
                AsientosDisponibles.Add(new Asiento(i, i, false));
            }
        }
        else
        {
            throw new ArgumentException("Error: Debe haber al menos un horario asociado a la sesión.");
        }
    }
}
