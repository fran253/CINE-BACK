namespace Models;

public class Horario
{
    public int IdHorario { get; set; }
    public DateTime Hora { get; set; }
    public Sala Sala { get; set; }

    public Horario(int idHorario, DateTime hora, Sala sala)
    {
        IdHorario = idHorario;
        Hora = hora;
        Sala = sala;
    }
}
