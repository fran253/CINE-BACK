namespace Models;

public class Sala {
    public int IdSala {get;set;}
    public string NombreSala {get; set;}
    public int Capacidad{get;set;}
    public int PrecioAsiento {get;set;}
    public List<Asiento> AsientosDisponibles { get; set; }


    




   public Sala(int idsala, int capacidad, string nombresala, int precioasiento)
        {
            IdSala = idsala;
            Capacidad = capacidad;
            NombreSala = nombresala;
            PrecioAsiento = precioasiento;


            // Inicializar la lista de asientos disponibles
            AsientosDisponibles = new List<Asiento>();
            for (int i = 1; i <= capacidad; i++)
            {
                // Crear cada asiento con el constructor parametrizado
                AsientosDisponibles.Add(new Asiento(
                    idasiento: i,
                    numasiento: i, 
                    libre: true 
                ));
            }
        }



    //public abstract void MostrarDetalles();

}
