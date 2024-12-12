using HydraulicFix.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace HydraulicFix.Services;

public class UserRolesService(ApplicationDbContext _contexto) : IServerAsp<IdentityUserRole<string>>
{
    public async Task<List<IdentityUserRole<string>>> GetAllObject()
    {
        return await _contexto.UserRoles.ToListAsync();
    }

    public async Task<IdentityUserRole<string>> GetObject(string id)
    {
        return (await _contexto.UserRoles.FirstOrDefaultAsync(r => r.RoleId == id))!;
    }

    public async Task<IdentityUserRole<string>> AddObject(IdentityUserRole<string> type)
    {
        _contexto.UserRoles.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(IdentityUserRole<string> type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(string roleId)
    {
        var userRole = await _contexto.UserRoles.FindAsync(roleId);
        if (userRole == null)
        {
            return false;
        }
        _contexto.UserRoles.Remove(userRole);
        return await _contexto.SaveChangesAsync() > 0;
    }
}

