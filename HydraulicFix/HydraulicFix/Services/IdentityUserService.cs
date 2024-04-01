namespace HydraulicFix.Services;

using HydraulicFix.Components.Account;
using HydraulicFix.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class IdentityUserService(UserManager<ApplicationUser> _userManager,
    RoleManager<IdentityRole> _roleManager, ApplicationDbContext _contexto)
{
    public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
    {
        user.EmailConfirmed = true;
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            return result;

        var adminRole = await _roleManager.FindByNameAsync("Admin");
        if (adminRole == null)
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _userManager.AddToRoleAsync(user, "Admin");
            return result;
        }


        var clienteRole = await _roleManager.FindByNameAsync("Cliente");
        if (clienteRole == null)
        {
            await _roleManager.CreateAsync(new IdentityRole("Cliente"));
            await _userManager.AddToRoleAsync(user, "Cliente");
        }

        await _userManager.AddToRoleAsync(user, "Cliente");
        return result;
    }

    public async Task<bool> EmailExisteAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user != null;
    }

    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<bool> GetNickNameAsync(string user)
    {
        return await _contexto.Users.FirstOrDefaultAsync(x => x.NickName == user) != null;
    }
    public async Task<bool> CedulaExistAsync(string user)
    {
        return await _contexto.Users.FirstOrDefaultAsync(x => x.Cedula == user) != null;
    }

    public async Task<IdentityRole> GetRoleAsync(ApplicationUser user)
    {
        IdentityUserRole<string> roles = (await _contexto.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id))!;

        if (roles != null)
        {
            return (await _contexto.Roles.FirstOrDefaultAsync(r => r.Id == roles.RoleId))!;
        }
        else
        {
            return null!;
        }
    }

    public async Task<bool> ChangeUserRoleAsync(ApplicationUser user, string newRoleName)
    {
        var existingRoles = await _userManager.GetRolesAsync(user);
        foreach (var existingRole in existingRoles)
        {
            await _userManager.RemoveFromRoleAsync(user, existingRole);
        }

        var existente = await _contexto.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id);
        if (existente == null)
        {
            var role = await _contexto.Roles.FirstOrDefaultAsync(x => x.Name == newRoleName);
            if (role == null)
            {
                _contexto.Roles.Add(new IdentityRole(newRoleName));
                await _contexto.SaveChangesAsync();
                var role2 = await _contexto.Roles.FirstOrDefaultAsync(x => x.Name == newRoleName);
                _contexto.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = role2!.Id });
            }
            else
            {
                _contexto.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = role!.Id });

            }
        }
        else
        {
            _contexto.UserRoles.Remove(existente);
            var role = await _contexto.Roles.FirstOrDefaultAsync(x => x.Name == newRoleName);
            if (role == null)
            {
                _contexto.Roles.Add(new IdentityRole(newRoleName));
                await _contexto.SaveChangesAsync();
                var role2 = await _contexto.Roles.FirstOrDefaultAsync(x => x.Name == newRoleName);
                _contexto.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = role2!.Id });
            }
            else
            {
                _contexto.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = role!.Id });

            }
        }
        return await _contexto.SaveChangesAsync() > 0;
    }
}
