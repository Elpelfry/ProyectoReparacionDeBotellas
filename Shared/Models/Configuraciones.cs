using System.ComponentModel.DataAnnotations;


namespace Shared.Models;

public class Configuraciones
{
    [Key]
    public int ConfiguracionId { get; set; }
    [Required(ErrorMessage = "El campo NFC es obligatorio.")]
    [StringLength(10, ErrorMessage = "El NFC debe ser de 10 caracteres")]
    public string? NFC { get; set; }
    public byte[]? Imagen { get; set; }
    public string? ImagenUrl { get; set; }
    [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
    public string? Telefono { get; set; }
    [Required(ErrorMessage = "Escriba el nombre de la empresa")]
    public string? NombreEmpresa { get; set; }
    [Required(ErrorMessage = "Escriba la dirección de la empresa")]
    public string? Direccion { get; set; }
    public string? Nota { get; set; }
}
