using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestGastosService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllGastos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new GastosService(context);
			await context.Gastos.AddRangeAsync(
				new Gastos { Fecha = DateTime.Now, Monto = 100, Asunto = "Asunto 1", Descripcion = "Descripción 1" },
				new Gastos { Fecha = DateTime.Now, Monto = 200, Asunto = "Asunto 2", Descripcion = "Descripción 2" },
				new Gastos { Fecha = DateTime.Now, Monto = 300, Asunto = "Asunto 3", Descripcion = "Descripción 3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task GetObject_ShouldReturnCorrectGasto()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new GastosService(context);
			await context.Gastos.AddRangeAsync(
				new Gastos { Fecha = DateTime.Now, Monto = 100, Asunto = "Asunto 1", Descripcion = "Descripción 1" },
				new Gastos { Fecha = DateTime.Now, Monto = 200, Asunto = "Asunto 2", Descripcion = "Descripción 2" },
				new Gastos { Fecha = DateTime.Now, Monto = 300, Asunto = "Asunto 3", Descripcion = "Descripción 3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObject(2);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(200, result.Monto);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewGasto()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new GastosService(context);
			var gasto = new Gastos { Fecha = DateTime.Now, Monto = 400, Asunto = "Nuevo Asunto", Descripcion = "Nueva Descripción" };

			// Act
			var result = await service.AddObject(gasto);

			// Assert
			Assert.IsNotNull(result);
			var addedGasto = await context.Gastos.FindAsync(result.GastoId);
			Assert.IsNotNull(addedGasto);
			Assert.AreEqual(gasto.Monto, addedGasto.Monto);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingGasto()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new GastosService(context);
			var gasto = new Gastos { Fecha = DateTime.Now, Monto = 100, Asunto = "Asunto Original", Descripcion = "Descripción Original" };
			await context.Gastos.AddAsync(gasto);
			await context.SaveChangesAsync();

			// Act
			gasto.Monto = 200;
			var result = await service.UpdateObject(gasto);

			// Assert
			Assert.IsTrue(result);
			var updatedGasto = await context.Gastos.FindAsync(gasto.GastoId);
			Assert.IsNotNull(updatedGasto);
			Assert.AreEqual(200, updatedGasto.Monto);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingGasto()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new GastosService(context);
			var gasto = new Gastos { Fecha = DateTime.Now, Monto = 100, Asunto = "Asunto Original", Descripcion = "Descripción Original" };
			await context.Gastos.AddAsync(gasto);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(gasto.GastoId);

			// Assert
			Assert.IsTrue(result);
			var deletedGasto = await context.Gastos.FindAsync(gasto.GastoId);
			Assert.IsNull(deletedGasto);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnGastosMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new GastosService(context);
			await context.Gastos.AddRangeAsync(
				new Gastos { Fecha = DateTime.Now, Monto = 100, Asunto = "Asunto 1", Descripcion = "Descripción 1" },
				new Gastos { Fecha = DateTime.Now, Monto = 200, Asunto = "Asunto 2", Descripcion = "Descripción 2" },
				new Gastos { Fecha = DateTime.Now, Monto = 300, Asunto = "Asunto 3", Descripcion = "Descripción 3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(g => g.Monto > 150);

			// Assert
			Assert.AreEqual(2, result.Count);
			Assert.IsTrue(result.All(g => g.Monto > 150));
		}
	}
}
