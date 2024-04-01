using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestMetodosPagosService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllMetodosPagos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new MetodosPagosService(context);
			await context.MetodoPagos.AddRangeAsync(
				new MetodoPagos { Nombre = "Tarjeta de crédito" },
				new MetodoPagos { Nombre = "Transferencia bancaria" },
				new MetodoPagos { Nombre = "Efectivo" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task GetObject_ShouldReturnMetodoPagoById()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new MetodosPagosService(context);
			var expectedMetodoPago = new MetodoPagos { Nombre = "Tarjeta de crédito" };
			await context.MetodoPagos.AddAsync(expectedMetodoPago);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObject(expectedMetodoPago.MetodoPagoId);

			// Assert
			Assert.AreEqual(expectedMetodoPago.Nombre, result.Nombre);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnMetodosPagosMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new MetodosPagosService(context);
			await context.MetodoPagos.AddRangeAsync(
				new MetodoPagos { Nombre = "Tarjeta de crédito" },
				new MetodoPagos { Nombre = "Transferencia bancaria" },
				new MetodoPagos { Nombre = "Efectivo" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(mp => mp.Nombre.StartsWith("T"));

			// Assert
			Assert.AreEqual(2, result.Count);
			Assert.IsTrue(result.All(mp => mp.Nombre.StartsWith("T")));
		}
	}
}
