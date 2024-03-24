using System.ComponentModel.DataAnnotations;


namespace Shared.Models
{
	public class Usuario
	{
		[Key]
		public int UsuarioId { get; set; }
		public int RolId { get; set; }

		[Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
		public string? NombreUsuario { get; set; }

		[Required(ErrorMessage = "Nombre requerido.")]
		public string? Nombre { get; set; }

		[Required(ErrorMessage = "Apellido requerido.")]
		public string? Apellido { get; set; }

		[Required(ErrorMessage = "La contraseña es obligatoria.")]
		public string? Contraseña { get; set; }

		[Required(ErrorMessage = "Es obligatorio")]
		public int Cedula { get; set; }

		[Required(ErrorMessage = "Es obligatorio")]
		[RegularExpression(@"^\w+@gmail\.com$", ErrorMessage = "El correo electrónico no es válido")]
		public string? Email { get; set; }

	}
}
