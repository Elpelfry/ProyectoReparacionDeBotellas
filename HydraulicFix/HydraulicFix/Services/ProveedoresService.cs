using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;

namespace HydraulicFix.Services;

public class ProveedoresService(ApplicationDbContext _contexto) : IServer<Proveedores>
{
    public async Task<List<Proveedores>> GetAllObject()
    {
        return await _contexto.Proveedores.ToListAsync();
    }

    public async Task<Proveedores> GetObject(int id)
    {
        return (await _contexto.Proveedores.FindAsync(id))!;
    }

    public async Task<Proveedores> AddObject(Proveedores type)
    {
        _contexto.Proveedores.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Proveedores type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var pro = await _contexto.Proveedores.FindAsync(id);
        if (pro == null)
            return false;
        _contexto.Proveedores.Remove(pro);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
