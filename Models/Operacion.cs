namespace Models;

public class Operacion {
    public int IdOperacion {get;set;}
    public Sesion Sesion {get;set;}
    //public string IdUsuario {get;set;}
    public Asiento Asiento {get;set;}
    //public int IdPelicula {get;set;}
    





    public Operacion(int idoperacion, Sesion sesion, Asiento asiento) {
        IdOperacion = idoperacion;
        Sesion = sesion;
        Asiento = asiento;
        // if (string.IsNullOrEmpty(nombre))
        // {
        //     throw new ArgumentException("Error: El nombre no puede estar vacío.");
        // }
        // if (precio < 0)
        // {
        //     throw new ArgumentException("Error: El precio no puede ser negativo.");
        // }
    }

    //public abstract void MostrarDetalles();

}
