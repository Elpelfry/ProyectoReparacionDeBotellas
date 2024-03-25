using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Abonos
{
    [Key]
    public int AbonoId { get; set; }

    public double Monto { get; set; }

    public double Restante { get; set; }

    [Required(ErrorMessage = "Es requerido")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    public string? Nota { get; set; }

    [ForeignKey("Ventas")]
    public int VentaId { get; set; }

    [ForeignKey("ApplicationUser")]
    public string? ClienteId { get; set; }
    public bool Pago { get; set; }

    [ForeignKey("AbonoId")]
    public ICollection<AbonosDetalle> AbonoDetalle { get; set; } = new List<AbonosDetalle>();
}
