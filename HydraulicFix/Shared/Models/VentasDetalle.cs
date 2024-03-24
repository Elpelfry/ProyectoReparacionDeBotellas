using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shared.Models
{
	public class VentasDetalle
	{
		[Key]
		public int DetalleID { get; set; }

		[ForeignKey("Venta")]
		public int VentaId { get; set; }

		[ForeignKey("Producto")]
		public int ProductoId { get; set; }

		[Required(ErrorMessage = "Es requerida la cantidad")]
		public int Cantidad { get; set; }
	}
}
