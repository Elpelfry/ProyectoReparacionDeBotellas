using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Estados
{
    [Key]
    public int EstadoId { get; set; }

    [Required(ErrorMessage = "El nombre del estado es obligatorio")]
    public string? NombreEstado { get; set; }
}
