using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace TestHydraulicFix;

[TestClass]
public class TestProveedoresService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllProveedores()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProveedoresService(context);
			await context.Proveedores.AddRangeAsync(
				new Proveedores { Nombre = "Proveedor 1", Telefono = "1234567890" },
				new Proveedores { Nombre = "Proveedor 2", Telefono = "9876543210" },
				new Proveedores { Nombre = "Proveedor 3", Telefono = "9998887776" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewProveedor()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProveedoresService(context);
			var proveedor = new Proveedores { Nombre = "Nuevo Proveedor", Telefono = "1112223334" };

			// Act
			var result = await service.AddObject(proveedor);

			// Assert
			Assert.IsNotNull(result);
			var addedProveedor = await context.Proveedores.FindAsync(result.ProveedorId);
			Assert.IsNotNull(addedProveedor);
			Assert.AreEqual(proveedor.Nombre, addedProveedor.Nombre);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingProveedor()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProveedoresService(context);
			var proveedor = new Proveedores { Nombre = "Proveedor Existente", Telefono = "5556667778" };
			await context.Proveedores.AddAsync(proveedor);
			await context.SaveChangesAsync();

			// Act
			proveedor.Telefono = "9998887776";
			var result = await service.UpdateObject(proveedor);

			// Assert
			Assert.IsTrue(result);
			var updatedProveedor = await context.Proveedores.FindAsync(proveedor.ProveedorId);
			Assert.IsNotNull(updatedProveedor);
			Assert.AreEqual("9998887776", updatedProveedor.Telefono);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingProveedor()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProveedoresService(context);
			var proveedor = new Proveedores { Nombre = "Proveedor a Eliminar", Telefono = "4445556667" };
			await context.Proveedores.AddAsync(proveedor);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(proveedor.ProveedorId);

			// Assert
			Assert.IsTrue(result);
			var deletedProveedor = await context.Proveedores.FindAsync(proveedor.ProveedorId);
			Assert.IsNull(deletedProveedor);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnProveedoresMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ProveedoresService(context);
			await context.Proveedores.AddRangeAsync(
				new Proveedores { Nombre = "Proveedor 1", Telefono = "1234567890" },
				new Proveedores { Nombre = "Proveedor 2", Telefono = "9876543210" },
				new Proveedores { Nombre = "Proveedor 3", Telefono = "9998887776" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(p => p.Nombre.Contains("Proveedor 2"));

			// Assert
			Assert.AreEqual(1, result.Count);
			Assert.IsTrue(result.All(p => p.Nombre.Contains("Proveedor 2")));
		}
	}
}
