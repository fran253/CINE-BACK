namespace Models;

public class Pelicula {
    public int IdPelicula {get;set;}
    public string Nombre {get;set;}
    public string Imagen {get;set;}
    public string Director {get;set;}
    public int Duracion {get;set;}
    public string Actores {get;set;}
    public string EdadMinima {get;set;}
    public DateTime FechaEstreno {get;set;}
    public string Descripcion {get;set;}
    public int IdCategoriaPelicula {get;set;}



    public Pelicula(int idpelicula, string nombre,string imagen, string director, int duracion, string actores, string edadminima, DateTime fechaestreno, string descripcion, int idCategoriaPelicula) {
        IdPelicula = idpelicula;
        Nombre = nombre;
        Imagen = imagen;
        Director = director;
        Duracion = duracion;
        Actores = actores;
        EdadMinima = edadminima;
        FechaEstreno = fechaestreno;
        Descripcion = descripcion;
        IdCategoriaPelicula = idCategoriaPelicula;

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
