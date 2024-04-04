using Microsoft.EntityFrameworkCore;
using HydraulicFix.Data;
using HydraulicFix.Services;
using Shared.Models;
using Microsoft.AspNetCore.Components;
using Moq;

namespace TestHydraulicFix;

[TestClass]
public class TestConfiguracionesService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllConfiguraciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);
			await context.Configuraciones.AddRangeAsync(
				new Configuraciones { NFC = "1111111111", Telefono = "8092446767" },
				new Configuraciones { NFC = "2222222222", Telefono = "8092446768" },
				new Configuraciones { NFC = "3333333333", Telefono = "8092446769" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task GetObject_ShouldReturnCorrectConfiguraciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);
			await context.Configuraciones.AddRangeAsync(
				new Configuraciones { NFC = "1111111111", Telefono = "8092446767" },
				new Configuraciones { NFC = "2222222222", Telefono = "8092446768" },
				new Configuraciones { NFC = "3333333333", Telefono = "8092446769" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObject(2);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("2222222222", result.NFC);
		}
	}

	[TestMethod]
	public async Task GetObject_ShouldReturnNullForNonExistingConfiguraciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);

			// Act
			var result = await service.GetObject(100);

			// Assert
			Assert.IsNull(result);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewConfiguraciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);
			var configuracion = new Configuraciones { NFC = "4444444444", Telefono = "8092446770" };

			// Act
			var result = await service.AddObject(configuracion);

			// Assert
			Assert.IsNotNull(result);
			var addedConfiguracion = await context.Configuraciones.FindAsync(result.ConfiguracionId);
			Assert.IsNotNull(addedConfiguracion);
			Assert.AreEqual(configuracion.NFC, addedConfiguracion.NFC);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingConfiguraciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);
			var configuracion = new Configuraciones { NFC = "1111111111", Telefono = "8092446767" };
			await context.Configuraciones.AddAsync(configuracion);
			await context.SaveChangesAsync();

			// Act
			configuracion.NFC = "1234567890";
			var result = await service.UpdateObject(configuracion);

			// Assert
			Assert.IsTrue(result);
			var updatedConfiguracion = await context.Configuraciones.FindAsync(configuracion.ConfiguracionId);
			Assert.IsNotNull(updatedConfiguracion);
			Assert.AreEqual("1234567890", updatedConfiguracion.NFC);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingConfiguraciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);
			var configuracion = new Configuraciones { NFC = "1111111111", Telefono = "8092446767" };
			await context.Configuraciones.AddAsync(configuracion);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(configuracion.ConfiguracionId);

			// Assert
			Assert.IsTrue(result);
			var deletedConfiguracion = await context.Configuraciones.FindAsync(configuracion.ConfiguracionId);
			Assert.IsNull(deletedConfiguracion);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldReturnFalseForNonExistingConfiguraciones()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);

			// Act
			var result = await service.DeleteObject(-1);

			// Assert
			Assert.IsFalse(result);
		}
	}

	[TestMethod]
	public async Task GetObjectByCondition_ShouldReturnConfiguracionesMatchingCondition()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);
			await context.Configuraciones.AddRangeAsync(
				new Configuraciones { NFC = "1111111111", Telefono = "8092446767" },
				new Configuraciones { NFC = "2222222222", Telefono = "8092446768" },
				new Configuraciones { NFC = "3333333333", Telefono = "8092446769" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetObjectByCondition(c => c.NFC.StartsWith("222"));

			// Assert
			Assert.AreEqual(1, result.Count);
			Assert.AreEqual("2222222222", result[0].NFC);
		}
	}

	[TestMethod]
	public async Task GuardarImagenYObtenerUrl_ShouldReturnValidUrl()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);
			var imagenBytes = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 };

			// Act
			var url = await service.GuardarImagenYObtenerUrl(imagenBytes, Mock.Of<NavigationManager>());

			// Assert
			Assert.IsNotNull(url);
			Assert.IsTrue(Uri.IsWellFormedUriString(url, UriKind.Absolute));
		}
	}

	[TestMethod]
	public async Task ObtenerConfiguracionActual_ShouldReturnValidConfiguracion()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new ConfiguracionesService(context);

			// Act
			var configuracionActual = await service.ObtenerConfiguracionActual();

			// Assert
			Assert.IsNotNull(configuracionActual);
			Assert.AreEqual("HydraulicFix", configuracionActual.NombreEmpresa);
		}
	}
}