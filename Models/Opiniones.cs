namespace Models;

public class Opiniones {
    public int IdOpinion {get;set;}
    public string NombreOpinante {get;set;}
    public string ApellidoOpinante {get;set;}
    public string Opinion {get;set;}
    public string Valoracion {get;set;}

    public Opiniones (int idopinion, string nombreopinante, string apellidoopinante, string opinion, string valoracion) {
        IdOpinion = idopinion;
        NombreOpinante = nombreopinante;
        ApellidoOpinante = apellidoopinante;
        Opinion = opinion;
        Valoracion = valoracion;

    }

}