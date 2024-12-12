namespace Shared.Dto;

public class ProductosDto
{
    public int ProductoId { get; set; }
    public int ProveedorId { get; set; }
    public int CategoriaId { get; set; }
    public string? Codigo { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public double Descuento { get; set; }
    public int ITBIS { get; set; }
    public bool EsDisponible { get; set; }
}
