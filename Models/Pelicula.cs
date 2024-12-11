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
    public string NombreCategoria {get; set;}
    public string TrailerUrl {get;set;}
    // public Opiniones Opiniones {get;set;}
    // public List<Opiniones> OpinionesDisponibles { get; set; }




    public Pelicula(int idpelicula, string nombre,string imagen, string director, int duracion, string actores, string edadminima, DateTime fechaestreno, string descripcion, int idCategoriaPelicula, string nombrecategoria, string trailerUrl) {
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
        NombreCategoria = nombrecategoria;
        TrailerUrl = trailerUrl;
        // Opiniones = opiniones;

        // if (string.IsNullOrEmpty(nombre))
        // {
        //     throw new ArgumentException("Error: El nombre no puede estar vacío.");
        // }
        // if (precio < 0)
        // {
        //     throw new ArgumentException("Error: El precio no puede ser negativo.");
        // }

        // OpinionesDisponibles = new List<Opiniones>();
        //         for (int i = 0; i < 4; i++)             {
        //         // Crear cada asiento con el constructor parametrizado
        //         OpinionesDisponibles.Add(new Opiniones(
        //             idopinion: i,
        //             nombreopinante: , 
        //             apellidoopinante: ,
        //             opinion: ,
        //             valoracion: 

        //         ));
        //     }
    }

    //public abstract void MostrarDetalles();

}
