using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestProductosService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllProductos()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProductosService(context);
			await context.Productos.AddRangeAsync(
				new Productos { Nombre = "Producto 1", Precio = 10.50, Cantidad = 100 },
				new Productos { Nombre = "Producto 2", Precio = 20.75, Cantidad = 200 },
				new Productos { Nombre = "Producto 3", Precio = 30.99, Cantidad = 150 }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewProducto()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProductosService(context);
			var producto = new Productos { Nombre = "Producto nuevo", Precio = 25.99, Cantidad = 50 };

			// Act
			var result = await service.AddObject(producto);

			// Assert
			Assert.IsNotNull(result);
			var addedProducto = await context.Productos.FindAsync(result.ProductoId);
			Assert.IsNotNull(addedProducto);
			Assert.AreEqual(producto.Nombre, addedProducto.Nombre);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingProducto()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProductosService(context);
			var producto = new Productos { Nombre = "Producto existente", Precio = 15.99, Cantidad = 75 };
			await context.Productos.AddAsync(producto);
			await context.SaveChangesAsync();

			// Act
			producto.Precio = 19.99;
			var result = await service.UpdateObject(producto);

			// Assert
			Assert.IsTrue(result);
			var updatedProducto = await context.Productos.FindAsync(producto.ProductoId);
			Assert.IsNotNull(updatedProducto);
			Assert.AreEqual(19.99, updatedProducto.Precio);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingProducto()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProductosService(context);
			var producto = new Productos { Nombre = "Producto a eliminar", Precio = 50.25, Cantidad = 30 };
			await context.Productos.AddAsync(producto);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(producto.ProductoId);

			// Assert
			Assert.IsTrue(result);
			var deletedProducto = await context.Productos.FindAsync(producto.ProductoId);
			Assert.IsNull(deletedProducto);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnProductosMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProductosService(context);
			await context.Productos.AddRangeAsync(
				new Productos { Nombre = "Producto 1", Precio = 10.50, Cantidad = 100 },
				new Productos { Nombre = "Producto 2", Precio = 20.75, Cantidad = 200 },
				new Productos { Nombre = "Producto 3", Precio = 30.99, Cantidad = 150 }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(p => p.Precio > 20);

			// Assert
			Assert.AreEqual(2, result.Count);
			Assert.IsTrue(result.All(p => p.Precio > 20));
		}
	}
}
