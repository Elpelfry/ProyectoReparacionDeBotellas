using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestCondicionesService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllCondiciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CondicionesService(context);
			await context.Condiciones.AddRangeAsync(
				new Condiciones { Nombre = "Condición 1" },
				new Condiciones { Nombre = "Condición 2" },
				new Condiciones { Nombre = "Condición 3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task GetObject_ShouldReturnCorrectCondiciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CondicionesService(context);
			await context.Condiciones.AddRangeAsync(
				new Condiciones { Nombre = "Condición 1" },
				new Condiciones { Nombre = "Condición 2" },
				new Condiciones { Nombre = "Condición 3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObject(2);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Condición 2", result.Nombre);
		}
	}

	[TestMethod]
	public async Task GetObject_ShouldReturnNullForNonExistingCondiciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CondicionesService(context);

			// Act
			var result = await service.GetObject(100);

			// Assert
			Assert.IsNull(result);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnCondicionesMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CondicionesService(context);
			await context.Condiciones.AddRangeAsync(
				new Condiciones { Nombre = "Condición A" },
				new Condiciones { Nombre = "Condición B" },
				new Condiciones { Nombre = "Condición C" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(c => c.Nombre.StartsWith("Condición B"));

			// Assert
			Assert.AreEqual(1, result.Count);
			Assert.AreEqual("Condición B", result[0].Nombre);
		}
	}
}
