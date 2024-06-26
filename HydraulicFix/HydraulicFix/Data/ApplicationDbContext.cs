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
    public DbSet<Gastos> Gastos { get; set; }

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
             new Estados { EstadoId = 2, NombreEstado = "En Proceso" },
             new Estados { EstadoId = 3, NombreEstado = "Completado" },
             new Estados { EstadoId = 4, NombreEstado = "Cancelado" }
        );
        modelBuilder.Entity<MetodoPagos>().HasData(
             new MetodoPagos { MetodoPagoId = 1, Nombre = "Efectivo" },
             new MetodoPagos { MetodoPagoId = 2, Nombre = "Tarjeta" }
        );
        modelBuilder.Entity<CategoriaProductos>().HasData(
             new CategoriaProductos { CategoriaId = 1, Nombre = "Sello mec�nico" },
             new CategoriaProductos { CategoriaId = 2, Nombre = "Limpiador" },
             new CategoriaProductos { CategoriaId = 3, Nombre = "Sello de pist�n" },
             new CategoriaProductos { CategoriaId = 4, Nombre = "Collar�n de fijaci�n" },
             new CategoriaProductos { CategoriaId = 5, Nombre = "Ret�n de eje" },
             new CategoriaProductos { CategoriaId = 6, Nombre = "Lubricante" },
             new CategoriaProductos { CategoriaId = 7, Nombre = "Filtro" },
             new CategoriaProductos { CategoriaId = 8, Nombre = "Ret�n de doble labio" },
             new CategoriaProductos { CategoriaId = 9, Nombre = "Sello de v�stago" },
             new CategoriaProductos { CategoriaId = 10, Nombre = "Sello de fibra" },
             new CategoriaProductos { CategoriaId = 11, Nombre = "Sello de v�lvula" }
        );
    }

    public void ConfigureProductosModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Productos>().HasData(
            new Productos { Cantidad = 4, Precio = 500, Descuento = 6, ITBIS = 4, Codigo = "1", ProductoId = 1, CategoriaId = 1, ProveedorId = 1, EsDisponible = true, Nombre = "Sello mec�nico de cartucho", },
            new Productos { Cantidad = 6, Precio = 200, Descuento = 6, ITBIS = 4, Codigo = "2", ProductoId = 2, CategoriaId = 2, ProveedorId = 2, EsDisponible = true, Nombre = "Limpiador hidr�ulio", },
            new Productos { Cantidad = 3, Precio = 240, Descuento = 6, ITBIS = 4, Codigo = "3", ProductoId = 3, CategoriaId = 3, ProveedorId = 3, EsDisponible = true, Nombre = "Sello de pist�n", },
            new Productos { Cantidad = 5, Precio = 450, Descuento = 6, ITBIS = 4, Codigo = "4", ProductoId = 4, CategoriaId = 4, ProveedorId = 4, EsDisponible = true, Nombre = "Collar�n de fijaci�n para ejes", },
            new Productos { Cantidad = 6, Precio = 200, Descuento = 6, ITBIS = 4, Codigo = "5", ProductoId = 5, CategoriaId = 5, ProveedorId = 5, EsDisponible = true, Nombre = "Ret�n de eje de goma", },
            new Productos { Cantidad = 3, Precio = 240, Descuento = 6, ITBIS = 4, Codigo = "6", ProductoId = 6, CategoriaId = 6, ProveedorId = 6, EsDisponible = true, Nombre = "Lubricante para rodamientos", },
            new Productos { Cantidad = 5, Precio = 450, Descuento = 6, ITBIS = 4, Codigo = "7", ProductoId = 7, CategoriaId = 7, ProveedorId = 7, EsDisponible = true, Nombre = "Filtro de aire", },
            new Productos { Cantidad = 6, Precio = 200, Descuento = 6, ITBIS = 4, Codigo = "8", ProductoId = 8, CategoriaId = 8, ProveedorId = 8, EsDisponible = true, Nombre = "Ret�n de doble labio", },
            new Productos { Cantidad = 3, Precio = 240, Descuento = 6, ITBIS = 4, Codigo = "9", ProductoId = 9, CategoriaId = 9, ProveedorId = 9, EsDisponible = true, Nombre = "Sello de v�stago para cilindros neum�ticos", },
            new Productos { Cantidad = 5, Precio = 450, Descuento = 6, ITBIS = 4, Codigo = "10", ProductoId = 10, CategoriaId = 10, ProveedorId = 10, EsDisponible = true, Nombre = "Sello de fibra de cer�mica.", },
            new Productos { Cantidad = 2, Precio = 100, Descuento = 6, ITBIS = 4, Codigo = "11", ProductoId = 11, CategoriaId = 11, ProveedorId = 11, EsDisponible = true, Nombre = "Sello de v�lvula de globo", }
        );

    }
}
