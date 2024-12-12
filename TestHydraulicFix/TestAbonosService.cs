using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestAbonosService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllAbonos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new AbonosService(context);
			await context.Abonos.AddRangeAsync(
				new Abonos { Monto = 100, Restante = 100, VentaId = 1 },
				new Abonos { Monto = 200, Restante = 200, VentaId = 2 },
				new Abonos { Monto = 300, Restante = 300, VentaId = 3 }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewAbonos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new AbonosService(context);
			var abono = new Abonos { Monto = 100, Restante = 100, VentaId = 1 };

			// Act
			var result = await service.AddObject(abono);

			// Assert
			Assert.IsNotNull(result);
			var addedAbono = await context.Abonos.FindAsync(result.AbonoId);
			Assert.IsNotNull(addedAbono);
			Assert.AreEqual(abono.Monto, addedAbono.Monto);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingAbonos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new AbonosService(context);
			var abono = new Abonos { Monto = 100, Restante = 100, VentaId = 1 };
			await context.Abonos.AddAsync(abono);
			await context.SaveChangesAsync();

			// Act
			abono.Monto = 200;
			var result = await service.UpdateObject(abono);

			// Assert
			Assert.IsTrue(result);
			var updatedAbono = await context.Abonos.FindAsync(abono.AbonoId);
			Assert.IsNotNull(updatedAbono);
			Assert.AreEqual(200, updatedAbono.Monto);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingAbonos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new AbonosService(context);
			var abono = new Abonos { Monto = 100, Restante = 100, VentaId = 1 };
			await context.Abonos.AddAsync(abono);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(abono.AbonoId);

			// Assert
			Assert.IsTrue(result);
			var deletedAbono = await context.Abonos.FindAsync(abono.AbonoId);
			Assert.IsNull(deletedAbono);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldReturnFalseForNonExistingAbonos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new AbonosService(context);

			// Act
			var result = await service.DeleteObject(-1);

			// Assert
			Assert.IsFalse(result);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnAbonosMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new AbonosService(context);
			await context.Abonos.AddRangeAsync(
				new Abonos { Monto = 100, Restante = 100, VentaId = 1 },
				new Abonos { Monto = 200, Restante = 200, VentaId = 2 },
				new Abonos { Monto = 300, Restante = 300, VentaId = 3 }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(a => a.Monto > 150);

			// Assert
			Assert.AreEqual(2, result.Count);
			Assert.IsTrue(result.All(a => a.Monto > 150));
		}
	}
}

