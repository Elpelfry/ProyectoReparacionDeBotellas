using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TestHydraulicFix;

[TestClass]
public class TestsUserRolesService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllUserRoles()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new UserRolesService(context);
			await context.UserRoles.AddRangeAsync(
				new IdentityUserRole<string> { RoleId = "1", UserId = "1" },
				new IdentityUserRole<string> { RoleId = "2", UserId = "2" },
				new IdentityUserRole<string> { RoleId = "3", UserId = "3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewUserRole()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new UserRolesService(context);
			var userRole = new IdentityUserRole<string> { RoleId = "1", UserId = "1" };

			// Act
			var result = await service.AddObject(userRole);

			// Assert
			Assert.IsNotNull(result);
			var addedUserRole = await context.UserRoles.FindAsync(result.RoleId, result.UserId);
			Assert.IsNotNull(addedUserRole);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingUserRole()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new UserRolesService(context);
			var userRole = new IdentityUserRole<string> { RoleId = "1", UserId = "1" };
			await context.UserRoles.AddAsync(userRole);
			await context.SaveChangesAsync();

			// Act
			userRole.RoleId = "2";
			var result = await service.UpdateObject(userRole);

			// Assert
			Assert.IsTrue(result);
			var updatedUserRole = await context.UserRoles.FindAsync(userRole.RoleId, userRole.UserId);
			Assert.IsNotNull(updatedUserRole);
			Assert.AreEqual("2", updatedUserRole.RoleId);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingUserRole()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new UserRolesService(context);
			var userRole = new IdentityUserRole<string> { RoleId = "1", UserId = "1" };
			await context.UserRoles.AddAsync(userRole);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(userRole.RoleId);

			// Assert
			Assert.IsTrue(result);
			var deletedUserRole = await context.UserRoles.FindAsync(userRole.RoleId, userRole.UserId);
			Assert.IsNull(deletedUserRole);
		}
	}
}
