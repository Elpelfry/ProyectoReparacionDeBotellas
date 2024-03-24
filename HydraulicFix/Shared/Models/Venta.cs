using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class Venta
	{
		[Key]
		public int VentaId { get; set; }
		[ForeignKey("Configuracion")]
		public int ConfiguracionId { get; set; }

		[ForeignKey("Usuario")]
		public int UsuarioId { get; set; }

		[ForeignKey("Reparacion")]
		public int ReparacionId { get; set; }

		[ForeignKey("MetodoPago")]
		public int MetodoPagoId { get; set; }
		public DateTime Fecha { get; set; } = DateTime.Now;
		public double SubTotal { get; set; }
		public double Costo { get; set; }
		public bool Eliminada { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public int Precio { get; set; }
		public int Descuento { get; set; }
		public double ITBS { get; set; }
		public double Total { get; set; }
		public double Deuda { get; set; }
		public double Cambio { get; set; }

		[ForeignKey("VentaId")]
		private ICollection<VentasDetalle> VentasDetalle { get;set;} = new List<VentasDetalle>();
	}
}
