using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TestHydraulicFix;

[TestClass]
public class RolesServiceTests
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllRoles()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new RolesService(context);
			await context.Roles.AddRangeAsync(
				new IdentityRole { Name = "Admin" },
				new IdentityRole { Name = "User" },
				new IdentityRole { Name = "Manager" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewRole()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new RolesService(context);
			var role = new IdentityRole { Name = "TestRole" };

			// Act
			var result = await service.AddObject(role);

			// Assert
			Assert.IsNotNull(result);
			var addedRole = await context.Roles.FindAsync(result.Id);
			Assert.IsNotNull(addedRole);
			Assert.AreEqual(role.Name, addedRole.Name);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingRole()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new RolesService(context);
			var role = new IdentityRole { Name = "ExistingRole" };
			await context.Roles.AddAsync(role);
			await context.SaveChangesAsync();

			// Act
			role.Name = "UpdatedRole";
			var result = await service.UpdateObject(role);

			// Assert
			Assert.IsTrue(result);
			var updatedRole = await context.Roles.FindAsync(role.Id);
			Assert.IsNotNull(updatedRole);
			Assert.AreEqual("UpdatedRole", updatedRole.Name);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingRole()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new RolesService(context);
			var role = new IdentityRole { Name = "RoleToDelete" };
			await context.Roles.AddAsync(role);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(role.Id);

			// Assert
			Assert.IsTrue(result);
			var deletedRole = await context.Roles.FindAsync(role.Id);
			Assert.IsNull(deletedRole);
		}
	}
}
