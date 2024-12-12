namespace Shared.Dto;

public class AbonosDetalleDto
{
    public int DetalleId { get; set; }
    public int AbonoId { get; set; }
    public int MetodoPagoId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public double Monto { get; set; }
}

