using HydraulicFix.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace HydraulicFix.Services;

public class RolesService(ApplicationDbContext _contexto) : IHydraulicAsp<IdentityRole>
{
    public async Task<IdentityRole> AddObject(IdentityRole type)
    {
        _contexto.Roles.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> DeleteObject(string id)
    {
        var user = await _contexto.Roles.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        _contexto.Roles.Remove(user);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<IdentityRole>> GetAllObject()
    {
        return await _contexto.Roles.ToListAsync();
    }

    public async Task<IdentityRole> GetObject(string id)
    {
        return (await _contexto.Roles.FindAsync(id))!;
    }

    public async Task<bool> UpdateObject(IdentityRole type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
}
