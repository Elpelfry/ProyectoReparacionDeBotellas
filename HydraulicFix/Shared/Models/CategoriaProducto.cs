using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class CategoriaProducto
	{
		[ForeignKey("Producto")]
		public int ProductoId { get; set; }
		public string? Nombre { get; set; }
		public string? Descripcion { get; set; }
		public List<Producto>? Productos { get; set; }
	}
}
