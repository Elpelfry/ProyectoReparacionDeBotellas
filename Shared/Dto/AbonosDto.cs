namespace Shared.Dto;

public class AbonosDto
{
    public int AbonoId { get; set; }
    public double Monto { get; set; }
    public double Restante { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string? Nota { get; set; }
    public int VentaId { get; set; }
    public string? ClienteId { get; set; }
    public bool Pago { get; set; }
    public ICollection<AbonosDetalleDto> AbonoDetalle { get; set; } = new List<AbonosDetalleDto>();
}
