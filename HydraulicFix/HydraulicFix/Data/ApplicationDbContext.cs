using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace HydraulicFix.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Abonos> Abonos { get; set; }
    public DbSet<AbonosDetalle> AbonosDetalle { get; set; }
    public DbSet<CategoriaProductos> CategoriaProductos { get; set; }
    public DbSet<Configuraciones> Configuraciones { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Proveedores> Proveedores { get; set; }
    public DbSet<Reparaciones> Reparaciones { get; set; }
    public DbSet<ReparacionesDetalle> ReparacionesDetalle { get; set; }
    public DbSet<Ventas> Ventas { get; set; }
    public DbSet<VentasDetalle> VentasDetalle { get; set; }
    public DbSet<Condiciones> Condiciones { get; set; }
    public DbSet<Estados> Estados { get; set; }
    public DbSet<MetodoPagos> MetodoPagos { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		ConfigureGeneralModel(modelBuilder);
		ConfigureProductosModel(modelBuilder);
	}
	public void ConfigureGeneralModel(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Condiciones>().HasData(
			 new Condiciones { CondicionId = 1, Nombre = "Contado" },
			 new Condiciones { CondicionId = 2, Nombre = "Credito" }
		);
		modelBuilder.Entity<Estados>().HasData(
			 new Estados { EstadoId = 1, NombreEstado = "Pendiente" },
			 new Estados { EstadoId = 2, NombreEstado = "EnProceso" },
			 new Estados { EstadoId = 3, NombreEstado = "Terminado" },
			 new Estados { EstadoId = 4, NombreEstado = "Cancelado" }
		);
		modelBuilder.Entity<MetodoPagos>().HasData(
			 new MetodoPagos { MetodoPagoId = 1, Nombre = "Efectivo" },
			 new MetodoPagos { MetodoPagoId = 2, Nombre = "Tarjeta" }
		);
	}

	public void ConfigureProductosModel(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Productos>().HasData(
			new Productos { Nombre = "Sello mecánico de cartucho", Cantidad = 4, Precio = 500, Descuento = 6.00, ITBIS = 4, ProductoId = 1, Codigo = "1111" },
			new Productos { Nombre = "Limpiador hidráulio", Cantidad = 6, Precio = 200, Descuento = 6.00, ITBIS = 4 , ProductoId = 2, Codigo = "1111" },
			new Productos { Nombre = "Sello de pistón", Cantidad = 3, Precio = 240, Descuento = 6.00, ITBIS = 4, ProductoId = 3, Codigo = "1111" },
			new Productos { Nombre = "Collarín de fijación para ejes", Cantidad = 5, Precio = 450, Descuento = 6.00, ITBIS = 4, ProductoId = 4, Codigo = "1111" },
			new Productos { Nombre = "Retén de eje de goma", Cantidad = 6, Precio = 200, Descuento = 6.00, ITBIS = 4, ProductoId = 5, Codigo = "1111" },
			new Productos { Nombre = "Lubricante para rodamientos", Cantidad = 3, Precio = 240, Descuento = 6.00, ITBIS = 4, ProductoId = 6, Codigo = "1111" },
			new Productos { Nombre = "Filtro de aire", Cantidad = 5, Precio = 450, Descuento = 6.00, ITBIS = 4, ProductoId = 7, Codigo = "1111" },
			new Productos { Nombre = "Retén de doble labio", Cantidad = 6, Precio = 200, Descuento = 6.00, ITBIS = 4, ProductoId = 8, Codigo = "1111"},
			new Productos { Nombre = "Sello de vástago para cilindros neumáticos", Cantidad = 3, Precio = 240, Descuento = 6.00, ITBIS = 4, ProductoId = 9, Codigo = "1111" },
			new Productos { Nombre = "Sello de fibra de cerámica.", Cantidad = 5, Precio = 450, Descuento = 6.00, ITBIS = 4, ProductoId = 10, Codigo = "1111" },
			new Productos { Nombre = "Sello de válvula de globo", Cantidad = 2, Precio = 100, Descuento = 6.00, ITBIS = 4, ProductoId = 11, Codigo= "1111" }
		);
	
	}
}
