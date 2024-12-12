using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestReparacionesService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllReparaciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ReparacionesService(context);
			await context.Reparaciones.AddRangeAsync(
				new Reparaciones { NombreCliente = "Cliente 1", ApellidoCliente = "Apellido 1", Tecnico = "Técnico 1", EstadoId = 1, Costo = 100.0f, Direccion = "Dirección 1", Descripcion = "Descripción 1", Telefono = "1234567890", Fecha = DateTime.Now },
				new Reparaciones { NombreCliente = "Cliente 2", ApellidoCliente = "Apellido 2", Tecnico = "Técnico 2", EstadoId = 2, Costo = 200.0f, Direccion = "Dirección 2", Descripcion = "Descripción 2", Telefono = "9876543210", Fecha = DateTime.Now },
				new Reparaciones { NombreCliente = "Cliente 3", ApellidoCliente = "Apellido 3", Tecnico = "Técnico 3", EstadoId = 3, Costo = 300.0f, Direccion = "Dirección 3", Descripcion = "Descripción 3", Telefono = "9998887776", Fecha = DateTime.Now }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewReparacion()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ReparacionesService(context);
			var reparacion = new Reparaciones { NombreCliente = "Nuevo Cliente", ApellidoCliente = "Nuevo Apellido", Tecnico = "Nuevo Técnico", EstadoId = 1, Costo = 100.0f, Direccion = "Nueva Dirección", Descripcion = "Nueva Descripción", Telefono = "1112223334", Fecha = DateTime.Now };

			// Act
			var result = await service.AddObject(reparacion);

			// Assert
			Assert.IsNotNull(result);
			var addedReparacion = await context.Reparaciones.FindAsync(result.ReparacionId);
			Assert.IsNotNull(addedReparacion);
			Assert.AreEqual(reparacion.NombreCliente, addedReparacion.NombreCliente);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingReparacion()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ReparacionesService(context);
			var reparacion = new Reparaciones { NombreCliente = "Cliente Existente", ApellidoCliente = "Apellido Existente", Tecnico = "Técnico Existente", EstadoId = 1, Costo = 100.0f, Direccion = "Dirección Existente", Descripcion = "Descripción Existente", Telefono = "5556667778", Fecha = DateTime.Now };
			await context.Reparaciones.AddAsync(reparacion);
			await context.SaveChangesAsync();

			// Act
			reparacion.Costo = 200.0f;
			var result = await service.UpdateObject(reparacion);

			// Assert
			Assert.IsTrue(result);
			var updatedReparacion = await context.Reparaciones.FindAsync(reparacion.ReparacionId);
			Assert.IsNotNull(updatedReparacion);
			Assert.AreEqual(200.0, updatedReparacion.Costo);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingReparacion()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ReparacionesService(context);
			var reparacion = new Reparaciones { NombreCliente = "Cliente a Eliminar", ApellidoCliente = "Apellido a Eliminar", Tecnico = "Técnico a Eliminar", EstadoId = 1, Costo = 100.0f, Direccion = "Dirección a Eliminar", Descripcion = "Descripción a Eliminar", Telefono = "4445556667", Fecha = DateTime.Now };
			await context.Reparaciones.AddAsync(reparacion);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(reparacion.ReparacionId);

			// Assert
			Assert.IsTrue(result);
			var deletedReparacion = await context.Reparaciones.FindAsync(reparacion.ReparacionId);
			Assert.IsNull(deletedReparacion);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnReparacionesMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ReparacionesService(context);
			await context.Reparaciones.AddRangeAsync(
				new Reparaciones { NombreCliente = "Cliente 1", ApellidoCliente = "Apellido 1", Tecnico = "Técnico 1", EstadoId = 1, Costo = 100.0f, Direccion = "Dirección 1", Descripcion = "Descripción 1", Telefono = "1234567890", Fecha = DateTime.Now },
				new Reparaciones { NombreCliente = "Cliente 2", ApellidoCliente = "Apellido 2", Tecnico = "Técnico 2", EstadoId = 2, Costo = 200.0f, Direccion = "Dirección 2", Descripcion = "Descripción 2", Telefono = "9876543210", Fecha = DateTime.Now },
				new Reparaciones { NombreCliente = "Cliente 3", ApellidoCliente = "Apellido 3", Tecnico = "Técnico 3", EstadoId = 3, Costo = 300.0f, Direccion = "Dirección 3", Descripcion = "Descripción 3", Telefono = "9998887776", Fecha = DateTime.Now }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(r => r.NombreCliente!.Contains("Cliente 2"));

			// Assert
			Assert.AreEqual(1, result.Count);
			Assert.IsTrue(result.All(r => r.NombreCliente!.Contains("Cliente 2")));
		}
	}
}
