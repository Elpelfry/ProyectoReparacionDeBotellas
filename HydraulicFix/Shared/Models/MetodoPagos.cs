using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class MetodoPagos
{
    [Key]
    public int MetodoPagoId { get; set; }
    [Required(ErrorMessage = "No puede estar Vacio")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    public string? Nombre { get; set; }
}
