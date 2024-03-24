using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shared.Models
{
	public class Proveedor
	{
		[Key]
		public int ProveedorId { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio.")]
		public string? Nombre { get; set; }

		[Required(ErrorMessage = "El número de teléfono es obligatorio.")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
		public string? Telefono { get; set; }

		[ForeignKey("Producto")]
		public int ProductoId { get; set; }

		
	}
}
