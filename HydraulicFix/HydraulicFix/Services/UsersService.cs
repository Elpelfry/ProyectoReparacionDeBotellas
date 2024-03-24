using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace HydraulicFix.Services;

public class UsersService(ApplicationDbContext _contexto) : IHydraulicAsp<ApplicationUser>
{
    public async Task<ApplicationUser> GetObject(string id)
    {
        return (await _contexto.Users.FindAsync(id))!;
    }

    public async Task<List<ApplicationUser>> GetAllObject()
    {
        return await _contexto.Users.ToListAsync();
    }

    public async Task<ApplicationUser> AddObject(ApplicationUser type)
    {
        _contexto.Users.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(ApplicationUser type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
        
    }
    public async Task<bool> DeleteObject(string id)
    {
        var user = await _contexto.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        _contexto.Users.Remove(user);
       return  await _contexto.SaveChangesAsync() > 0;
    }
}
