namespace Models;

public class Comida {
    public int IdComplemento {get;set;}
    public string ImagenComplemento {get;set;}
    public string NombreComplemento {get;set;}
    public string DescripcionComplemento {get;set;}
    public double PrecioComplemento {get;set;} 
    


    public Comida(int idcomplemento, string imagencomplemento, string nombrecomplemento, string descripcioncomplemento, double preciocomplemento){
        IdComplemento = idcomplemento;
        ImagenComplemento = imagencomplemento;
        NombreComplemento = nombrecomplemento;
        DescripcionComplemento = descripcioncomplemento;
        PrecioComplemento = preciocomplemento;
    }
}