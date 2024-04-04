using HydraulicFix.Services;
using Moq;
using Shared.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace TestHydraulicFix;

public class ProductosTests
{
	[Fact]
	public void ValidaNombreProducto()
	{
		// Arrange
		var producto = new Shared.Models.Productos();

		// Act
		var validationResults = new List<ValidationResult>();
		var isValid = Validator.TryValidateObject(producto, new ValidationContext(producto), validationResults);

		// Assert
		Assert.IsFalse(isValid);
	}

	[Fact]
	public void ValidaProductoVacio()
	{
		// Arrange
		var mockProductosService = new Mock<ProductosService>();
		var productos = new Productos();

		// Act
		var validationResults = new List<ValidationResult>();
		var isValid = Validator.TryValidateObject(productos, new ValidationContext(productos), validationResults);

		// Assert
		Assert.IsTrue(isValid);


		mockProductosService.VerifyNoOtherCalls();
	}
}
