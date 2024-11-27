namespace Models;

public class Asiento {
    public int IdAsiento { get; set; }
    public int NumAsiento { get; set; }
    public bool Estado { get; set; } // true = ocupado, false = libre

    public Asiento(int idasiento, int numasiento, bool estado) {
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
