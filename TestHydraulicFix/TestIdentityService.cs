using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace TestHydraulicFix;

[TestClass]
public class TestIdentityUserService
{
	[TestMethod]
	public async Task CreateUserAsync_ShouldCreateUserAndAssignRoles()
	{
		// Arrange
		var userManagerMock = new Mock<UserManager<ApplicationUser>>(MockBehavior.Strict, null, null, null, null, null, null, null, null);
		var roleManagerMock = new Mock<RoleManager<IdentityRole>>(MockBehavior.Strict, null, null, null, null, null);
		var contextoMock = new Mock<ApplicationDbContext>(MockBehavior.Strict);

		var user = new ApplicationUser { UserName = "testUser", Email = "test@example.com" };
		var password = "password";
		var identityResult = IdentityResult.Success;

		userManagerMock.Setup(x => x.CreateAsync(user, password)).ReturnsAsync(identityResult);
		userManagerMock.Setup(x => x.FindByEmailAsync(user.Email)).ReturnsAsync(user);

		var adminRole = new IdentityRole("Admin");
		var clienteRole = new IdentityRole("Cliente");
		roleManagerMock.Setup(x => x.FindByNameAsync("Admin")).ReturnsAsync(adminRole);
		roleManagerMock.Setup(x => x.FindByNameAsync("Cliente")).ReturnsAsync(clienteRole);
		roleManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityRole>())).ReturnsAsync(IdentityResult.Success);

		var identityUserService = new IdentityUserService(userManagerMock.Object, roleManagerMock.Object, contextoMock.Object);

		// Act
		var result = await identityUserService.CreateUserAsync(user, password);

		// Assert
		Assert.AreEqual(IdentityResult.Success, result);
		userManagerMock.Verify(x => x.CreateAsync(user, password), Times.Once);
		userManagerMock.Verify(x => x.FindByEmailAsync(user.Email), Times.Once);
		roleManagerMock.Verify(x => x.FindByNameAsync("Admin"), Times.AtLeastOnce);
		roleManagerMock.Verify(x => x.FindByNameAsync("Cliente"), Times.AtLeastOnce);
		roleManagerMock.Verify(x => x.CreateAsync(It.IsAny<IdentityRole>()), Times.AtLeastOnce);
	}

	// Add tests for other methods...
}
