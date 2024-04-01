using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Reparaciones
{
    [Key]
    public int ReparacionId { get; set; }
    [ForeignKey("ApplicationUser")]
    public string? ClienteId { get; set; }

    [Required(ErrorMessage = "El Combre del cliente es obligatorio")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    public string? NombreCliente { get; set; }

    [Required(ErrorMessage = "El Técnico es obligatorio")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    public string? Tecnico { get; set; }

    [ForeignKey("Estados")]
    public int EstadoId { get; set; }

    [Required(ErrorMessage = "El Apellido del cliente es obligatorio")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Apellido debe contener solo letras.")]
    public string? ApellidoCliente { get; set; }

    [Required(ErrorMessage = "Indique el Costo a abonar")]
    [Range(0.01f, 1000000000, ErrorMessage = "El Costo debe estar 0.01 y 1000000000")]
    public double Costo { get; set; }

    [Required(ErrorMessage = "La Dirección es obligatoria")]
    public string? Direccion { get; set; }

    [Required(ErrorMessage = "La Descripción es obligatoria")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El Teléfono es obligatori")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "La Fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [ForeignKey("ReparacionId")]
    public ICollection<ReparacionesDetalle> ReparacionDetalle { get; set; } = new List<ReparacionesDetalle>();
}
