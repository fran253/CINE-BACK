namespace Models;

public class Asiento {
    public int IdAsiento {get;set;}
    public int NumAsiento {get;set;}
    public Boolean Estado {get;set;}




    public Asiento(int idasiento, int numasiento, Boolean estado) {
        IdAsiento = idasiento;
        NumAsiento = numasiento;
        Estado = estado;
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
