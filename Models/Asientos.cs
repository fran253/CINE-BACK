namespace Models;

public class Asiento {
    public int IdAsiento {get;set;}
    public int NumAsiento {get;set;}
    public Boolean Libre {get;set;}




    public Asiento(int idasiento, int numasiento, Boolean libre) {
        IdAsiento = idasiento;
        NumAsiento = numasiento;
        Libre = libre;
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
