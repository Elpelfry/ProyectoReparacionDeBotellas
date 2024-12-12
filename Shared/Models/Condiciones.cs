using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Condiciones
{
    [Key]
    public int CondicionId { get; set; }
    [Required(ErrorMessage = "Es Requerido")]
    public string? Nombre { get; set; }

}
