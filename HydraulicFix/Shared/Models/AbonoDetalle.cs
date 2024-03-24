using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shared.Models
{
	public class AbonoDetalle
	{
		[Key]
		public int DetalleId { get; set; }

		[ForeignKey("Abono")]
		public int AbonoId { get; set; }

		[Required(ErrorMessage = "El SBC es obligatorio")]
		public string? SBC { get; set; }
		public DateTime Fecha { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Indique el monto a abonar")]
		public decimal Monto { get; set; }
		public bool Pago { get; set; }
	}
}

