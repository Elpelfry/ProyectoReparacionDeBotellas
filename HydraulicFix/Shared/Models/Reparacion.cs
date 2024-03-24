using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class Reparacion
	{
		[Key]
		public int ReparacionId { get; set; }
		[ForeignKey("Usuario")]
		public int UsuarioId { get; set; }

		[Required(ErrorMessage = "El nombre del cliente es obligatorio")]
		public string? NombreCliente { get; set; }

		[ForeignKey("Tecnico")]
		public string? TecnicoId { get; set; }

		[ForeignKey("Estado")]
		public int EstadoId { get; set; }

		[Required(ErrorMessage = "El apellido del cliente es obligatorio")]
		public string? ApellidoCliente { get; set; }

		[Required(ErrorMessage = "Campo obligatorio")]
		public string? TipoSello { get; set; }
		public DateTime Fecha { get; set; } = DateTime.Now;

		[Range(1, int.MaxValue, ErrorMessage = "La cantidad de sellos debe ser mayor/igual a 1")]
		public int CantidadSello { get; set; }
		public double Costo { get; set; }

		[Required(ErrorMessage = "La dirección es obligatoria")]
		public string? Direccion { get; set; }

		[Required(ErrorMessage = "La descripción es obligatoria")]
		public string? Descripcion { get; set; }

		[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos")]
		public string? Telefono { get; set; }

		[ForeignKey("ReparacionId")]
		private ICollection<ReparacionDetalle> ReparacionDetalle = new List<ReparacionDetalle>();
	}
}
