using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class Abono
	{
		[Key]
		public int AbonoId { get; set; }
		[Required(ErrorMessage = "El monto es obligatorio")]
		public decimal Monto { get; set; }
		public DateTime Fecha { get; set; } = DateTime.Now;
		public string? Nota { get; set; }

		[ForeignKey("Venta")]
		public int VentaId { get; set; }

		[ForeignKey("Cliente")]
		public int ClienteId { get; set; }
	}
}
