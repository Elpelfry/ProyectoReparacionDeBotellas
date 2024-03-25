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
}
