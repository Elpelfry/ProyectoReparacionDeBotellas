using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shared.Models
{
	public class Producto
	{
		[Key]
		public int ProductoId { get; set; }

		[ForeignKey("Proveedor")]
		public int ProveedorId { get; set; }
		public int TipoId { get; set; }
		public string? Codigo { get; set; }
		public double Precio { get; set; }
		public int Cantidad { get; set; }
		public double Descuento { get; set; }
		public double ITBIS { get; set; }
		public bool EsDisponible { get; set; }
	}
}
