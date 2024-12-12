using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestEstadosService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllEstados()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new EstadosService(context);
			await context.Estados.AddRangeAsync(
				new Estados { NombreEstado = "Estado 1" },
				new Estados { NombreEstado = "Estado 2" },
				new Estados { NombreEstado = "Estado 3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task GetObject_ShouldReturnCorrectEstado()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new EstadosService(context);
			await context.Estados.AddRangeAsync(
				new Estados { NombreEstado = "Estado 1" },
				new Estados { NombreEstado = "Estado 2" },
				new Estados { NombreEstado = "Estado 3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObject(2);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Estado 2", result.NombreEstado);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnEstadosMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new EstadosService(context);
			await context.Estados.AddRangeAsync(
				new Estados { NombreEstado = "Estado 1" },
				new Estados { NombreEstado = "Estado 2" },
				new Estados { NombreEstado = "Estado 3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(e => e.NombreEstado.StartsWith("Estado 2"));

			// Assert
			Assert.AreEqual(1, result.Count);
			Assert.AreEqual("Estado 2", result[0].NombreEstado);
		}
	}
}
