
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Gastos
{
    [Key]
    public int GastoId { get; set; }

    [Required(ErrorMessage ="Es requerido una fecha")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Es requerido un monto")]
    [Range(0.01f, 1000000000, ErrorMessage = "El monto debe ser mayor a 0.01 y menor a 1000000000")]
    public double Monto { get; set; }

    [Required(ErrorMessage = "Es requerido un asunto")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo de acepta letras.")]
    public string? Asunto { get; set; }

    [Required(ErrorMessage = "Es requerido una descripción")]
    public string? Descripcion { get; set; }
}
