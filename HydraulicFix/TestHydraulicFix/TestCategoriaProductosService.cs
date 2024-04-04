using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestCategoriaProductosService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllCategoriaProductos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CategoriaProductosService(context);
			await context.CategoriaProductos.AddRangeAsync(
				new CategoriaProductos { Nombre = "Electrónicos" },
				new CategoriaProductos { Nombre = "Ropa" },
				new CategoriaProductos { Nombre = "Hogar" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewCategoriaProductos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CategoriaProductosService(context);
			var categoria = new CategoriaProductos { Nombre = "Electrónicos" };

			// Act
			var result = await service.AddObject(categoria);

			// Assert
			Assert.IsNotNull(result);
			var addedCategoria = await context.CategoriaProductos.FindAsync(result.CategoriaId);
			Assert.IsNotNull(addedCategoria);
			Assert.AreEqual(categoria.Nombre, addedCategoria.Nombre);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingCategoriaProductos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CategoriaProductosService(context);
			var categoria = new CategoriaProductos { Nombre = "Electrónicos" };
			await context.CategoriaProductos.AddAsync(categoria);
			await context.SaveChangesAsync();

			// Act
			categoria.Nombre = "Electrónicos Actualizados";
			var result = await service.UpdateObject(categoria);

			// Assert
			Assert.IsTrue(result);
			var updatedCategoria = await context.CategoriaProductos.FindAsync(categoria.CategoriaId);
			Assert.IsNotNull(updatedCategoria);
			Assert.AreEqual("Electrónicos Actualizados", updatedCategoria.Nombre);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingCategoriaProductos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CategoriaProductosService(context);
			var categoria = new CategoriaProductos { Nombre = "Electrónicos" };
			await context.CategoriaProductos.AddAsync(categoria);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(categoria.CategoriaId);

			// Assert
			Assert.IsTrue(result);
			var deletedCategoria = await context.CategoriaProductos.FindAsync(categoria.CategoriaId);
			Assert.IsNull(deletedCategoria);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldReturnFalseForNonExistingCategoriaProductos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CategoriaProductosService(context);

			// Act
			var result = await service.DeleteObject(-1);

			// Assert
			Assert.IsFalse(result);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnCategoriaProductosMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new CategoriaProductosService(context);
			await context.CategoriaProductos.AddRangeAsync(
				new CategoriaProductos { Nombre = "Electrónicos" },
				new CategoriaProductos { Nombre = "Ropa" },
				new CategoriaProductos { Nombre = "Hogar" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(c => c.Nombre.StartsWith("R"));

			// Assert
			Assert.AreEqual(1, result.Count);
			Assert.AreEqual("Ropa", result[0].Nombre);
		}
	}
}
