using HydraulicFix.Data;
using HydraulicFix.Services;
using Microsoft.EntityFrameworkCore;

namespace TestHydraulicFix;

[TestClass]
public class TestsUsersService
{
	[TestMethod]
	public async Task GetAllObject_ShouldReturnAllUsers()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new UsersService(context);
			await context.Users.AddRangeAsync(
				new ApplicationUser { Id = "1", UserName = "user1" },
				new ApplicationUser { Id = "2", UserName = "user2" },
				new ApplicationUser { Id = "3", UserName = "user3" }
			);
			await context.SaveChangesAsync();

			// Act
			var result = await service.GetAllObject();

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}

	[TestMethod]
	public async Task AddObject_ShouldAddNewUser()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new UsersService(context);
			var user = new ApplicationUser { Id = "1", UserName = "user1" };

			// Act
			var result = await service.AddObject(user);

			// Assert
			Assert.IsNotNull(result);
			var addedUser = await context.Users.FindAsync(result.Id);
			Assert.IsNotNull(addedUser);
		}
	}

	[TestMethod]
	public async Task UpdateObject_ShouldUpdateExistingUser()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new UsersService(context);
			var user = new ApplicationUser { Id = "1", UserName = "user1" };
			await context.Users.AddAsync(user);
			await context.SaveChangesAsync();

			// Act
			user.UserName = "updatedUser1";
			var result = await service.UpdateObject(user);

			// Assert
			Assert.IsTrue(result);
			var updatedUser = await context.Users.FindAsync(user.Id);
			Assert.IsNotNull(updatedUser);
			Assert.AreEqual("updatedUser1", updatedUser.UserName);
		}
	}

	[TestMethod]
	public async Task DeleteObject_ShouldDeleteExistingUser()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDatabase")
			.Options;

		using (var context = new ApplicationDbContext(options))
		{
			var service = new UsersService(context);
			var user = new ApplicationUser { Id = "1", UserName = "user1" };
			await context.Users.AddAsync(user);
			await context.SaveChangesAsync();

			// Act
			var result = await service.DeleteObject(user.Id);

			// Assert
			Assert.IsTrue(result);
			var deletedUser = await context.Users.FindAsync(user.Id);
			Assert.IsNull(deletedUser);
		}
	}
}
