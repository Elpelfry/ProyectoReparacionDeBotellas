namespace Shared.Dto;

public class VentasDto
{
	public int VentaId { get; set; }
	public int ConfiguracionId { get; set; }
	public string? ClienteId { get; set; }
	public int ReparacionId { get; set; }
	public int MetodoPagoId { get; set; }
	public DateTime Fecha { get; set; } = DateTime.Now;
	public double SubTotal { get; set; }
	public double Total { get; set; }
	public double ITBS { get; set; }
	public double Recibido { get; set; }
	public double Devuelta { get; set;}
	public int CondicionId { get; set; }
	public bool Eliminada { get; set; }
	public ICollection<VentasDetalleDto> VentasDetalle { get;set;} = new List<VentasDetalleDto>();
}
