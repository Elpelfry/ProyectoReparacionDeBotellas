using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Ventas
{
	[Key]
	public int VentaId { get; set; }
	[ForeignKey("Configuraciones")]
	public int ConfiguracionId { get; set; }

	[ForeignKey("ApplicationUser")]
	public string? ClienteId { get; set; }

    [Required(ErrorMessage = "El Combre del cliente es obligatorio")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    public string? NombreCliente { get; set; }

    [ForeignKey("Reparaciones")]
	public int ReparacionId { get; set; }

	[ForeignKey("MetodoPagos")]
	public int MetodoPagoId { get; set; }

	[Required(ErrorMessage = "Es requerido")]
	public DateTime Fecha { get; set; } = DateTime.Now;

	public double SubTotal { get; set; }

	public double Total { get; set; }

	public double ITBS { get; set; }

	public double Recibido { get; set; }

	public double Devuelta { get; set;}

	[ForeignKey("Condiciones")]
	public int CondicionId { get; set; }

	public bool Eliminada { get; set; }

	[ForeignKey("VentaId")]
	public ICollection<VentasDetalle> VentasDetalle { get;set;} = new List<VentasDetalle>();
}
