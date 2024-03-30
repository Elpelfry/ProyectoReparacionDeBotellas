using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace HydraulicFix.Services;

public class VentasService(ApplicationDbContext _contexto): IServer<Ventas>
{
    public async Task<List<Ventas>> GetAllObject()
    {
        return await _contexto.Ventas.Include(v => v.VentasDetalle).ToListAsync();
    }

    public async Task<Ventas> GetObject(int id)
    {
        return (await _contexto.Ventas.Include(v => v.VentasDetalle).FirstOrDefaultAsync(v => v.VentaId == id))!;
    }

    public async Task<Ventas> AddObject(Ventas type)
    {
        _contexto.Ventas.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Ventas type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var venta = await _contexto.Ventas.FindAsync(id);
        if (venta == null)
            return false;

        await _contexto.VentasDetalle.Where(v => v.VentaId == id).ExecuteDeleteAsync();
        _contexto.Ventas.Remove(venta);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<List<Ventas>> GetObjectByCondition(Expression<Func<Ventas, bool>> expression)
    {
        return await _contexto.Ventas.Include(v => v.VentasDetalle)
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}

