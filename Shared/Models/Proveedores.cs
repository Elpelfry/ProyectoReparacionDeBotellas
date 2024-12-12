using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Proveedores
{
    [Key]
    public int ProveedorId { get; set; }
    [Required(ErrorMessage = "El Nombre es obligatorio.")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El Número de teléfono es obligatorio.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
    public string? Telefono { get; set; }

}
