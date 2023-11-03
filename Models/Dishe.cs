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

    [Required(ErrorMessage ="Por favor proporciona este dato")]
    [Range(1, 5, ErrorMessage = "El sabor debe estar entre 1 y 5")]
    public int Tastiness {get; set;}

    [Required(ErrorMessage ="Por favor proporciona este dato")]
    [Range(1, int.MaxValue, ErrorMessage = "Las calorías deben ser superiores a 0")]
    public int Calories {get; set;}

    [Required(ErrorMessage ="Por favor proporciona este dato")]
    public string Description {get; set;}
    public DateTime Fecha_Creacion {get; set;} = DateTime.Now;
    public DateTime Fecha_Actualizacion {get; set;} = DateTime.Now;

}   