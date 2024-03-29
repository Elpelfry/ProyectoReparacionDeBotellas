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
			new Productos { Cantidad = 4, Precio = 500, Descuento = 6.00, ITBIS = 4, ProductoId = 1, CategoriaId = 1, ProveedorId = 1, EsDisponible = true, Nombre = "Sello mecánico de cartucho", },
			new Productos { Cantidad = 6, Precio = 200, Descuento = 6.00, ITBIS = 4, ProductoId = 2, CategoriaId = 2, ProveedorId = 2, EsDisponible = true, Nombre = "Limpiador hidráulio", },
			new Productos { Cantidad = 3, Precio = 240, Descuento = 6.00, ITBIS = 4, ProductoId = 3, CategoriaId = 3, ProveedorId = 3, EsDisponible = true, Nombre = "Sello de pistón", },
			new Productos { Cantidad = 5, Precio = 450, Descuento = 6.00, ITBIS = 4, ProductoId = 4, CategoriaId = 4, ProveedorId = 4, EsDisponible = true, Nombre = "Collarín de fijación para ejes", },
			new Productos { Cantidad = 6, Precio = 200, Descuento = 6.00, ITBIS = 4, ProductoId = 5, CategoriaId = 5, ProveedorId = 5, EsDisponible = true, Nombre = "Retén de eje de goma", },
			new Productos { Cantidad = 3, Precio = 240, Descuento = 6.00, ITBIS = 4, ProductoId = 6, CategoriaId = 6, ProveedorId = 6, EsDisponible = true, Nombre = "Lubricante para rodamientos", },
			new Productos { Cantidad = 5, Precio = 450, Descuento = 6.00, ITBIS = 4, ProductoId = 7, CategoriaId = 7, ProveedorId = 7, EsDisponible = true, Nombre = "Filtro de aire", },
			new Productos { Cantidad = 6, Precio = 200, Descuento = 6.00, ITBIS = 4, ProductoId = 8, CategoriaId = 8, ProveedorId = 8, EsDisponible = true, Nombre = "Retén de doble labio", },
			new Productos { Cantidad = 3, Precio = 240, Descuento = 6.00, ITBIS = 4, ProductoId = 9, CategoriaId = 9, ProveedorId = 9, EsDisponible = true, Nombre = "Sello de vástago para cilindros neumáticos", },
			new Productos { Cantidad = 5, Precio = 450, Descuento = 6.00, ITBIS = 4, ProductoId = 10, CategoriaId = 10, ProveedorId = 10, EsDisponible = true, Nombre = "Sello de fibra de cerámica.", },
			new Productos { Cantidad = 2, Precio = 100, Descuento = 6.00, ITBIS = 4, ProductoId = 11, CategoriaId = 11, ProveedorId = 11, EsDisponible = true, Nombre = "Sello de válvula de globo", }
		);

	}
}
