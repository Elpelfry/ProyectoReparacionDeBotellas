namespace Shared.Dto;

public class ReparacionesDto
{
    public int ReparacionId { get; set; }
    public string? ClienteId { get; set; }
    public string? NombreCliente { get; set; }
    public string? Tecnico { get; set; }
    public int EstadoId { get; set; }
    public string? ApellidoCliente { get; set; }
    public double Costo { get; set; }
    public string? Direccion { get; set; }
    public string? Descripcion { get; set; }
    public string? Telefono { get; set; }
    public DateTime Fecha { get; set; }
    public ICollection<ReparacionesDetalleDto> ReparacionDetalle { get; set; } = new List<ReparacionesDetalleDto>();
}
