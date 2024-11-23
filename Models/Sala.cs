namespace Models;

public class Sala {
    public int IdSala {get;set;}
    public string NombreSala {get; set;}
    public int Capacidad{get;set;}
    public List<Asiento> AsientosDisponibles { get; set; }


    




   public Sala(int idsala, int capacidad, string nombresala)
        {
            IdSala = idsala;
            Capacidad = capacidad;
            NombreSala = nombresala;

            // Inicializar la lista de asientos disponibles
            AsientosDisponibles = new List<Asiento>();
            for (int i = 1; i <= capacidad; i++)
            {
                // Crear cada asiento con el constructor parametrizado
                AsientosDisponibles.Add(new Asiento(
                    idasiento: i,
                    numasiento: i, 
                    estado: true 
                ));
            }
        }



    //public abstract void MostrarDetalles();

}
