using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
	public class Inventario
	{
		public string? Tipo { get; set; }
		public decimal Precio { get; set; }
		public int Cantidad { get; set; }
		public decimal Descuento { get; set; }
		public int? ITBIS { get; set; }

		public string DescuentoPorcentaje
		{
			get { return (Descuento * 100).ToString("0.00") + "%"; }
		}
	}
}
