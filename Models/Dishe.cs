#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dishe{
    [Key]
    public int Id {get; set;}

    [Required(ErrorMessage ="Por favor proporciona este dato")]
    public string Name {get; set;}

    [Required(ErrorMessage ="Por favor proporciona este dato")]
    public string Chef {get; set;}

    
    public int Tastiness {get; set;}
    public int Calories {get; set;}
    public string Description {get; set;}
    public DateTime Fecha_Creacion {get; set;} = DateTime.Now;
    public DateTime Fecha_Actualizacion {get; set;} = DateTime.Now;

}   