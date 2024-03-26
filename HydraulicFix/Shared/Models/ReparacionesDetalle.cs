using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class ReparacionesDetalle
{
	[Key]
	public int DetalleId { get; set; }

	[ForeignKey("Reparaciones")]
	public int ReparacionId { get; set; }

	[ForeignKey("Productos")]
	public int ProductoId { get; set; }

	[Required(ErrorMessage = "Es requerido")]
	public int CantidadUsada { get; set; }

}
