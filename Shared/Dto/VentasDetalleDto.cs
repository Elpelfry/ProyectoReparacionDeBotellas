namespace Shared.Dto;

public class VentasDetalleDto
{
	public int DetalleID { get; set; }
	public int VentaId { get; set; }
	public int ProductoId { get; set; }
	public int Cantidad { get; set; }
}
