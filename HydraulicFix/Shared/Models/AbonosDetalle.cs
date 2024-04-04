using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shared.Models;

public class AbonosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("Abonos")]
    public int AbonoId { get; set; }

    [ForeignKey("MetodoPagos")]
    public int MetodoPagoId { get; set; }

    [Required(ErrorMessage = "El Fecha es obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Indique el monto a abonar")]
    [Range(0.01, 1000000000, ErrorMessage = "El Monto debe estar 0.01 y 1000000000")]
    public float Monto { get; set; }

}

