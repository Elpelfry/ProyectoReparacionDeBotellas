using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace HydraulicFix.Services;

public class ReparacionesService(ApplicationDbContext _contexto) : IServer<Reparaciones>
{
    public Task<List<Reparaciones>> GetAllObject()
    {
        return _contexto.Reparaciones
            .Include(d => d.ReparacionDetalle)
                .ToListAsync();
    }

    public async Task<Reparaciones> GetObject(int id)
    {
        return (await _contexto.Reparaciones.Include(d => d.ReparacionDetalle)
            .FirstOrDefaultAsync(r => r.ReparacionId == id))!;
    }

    public async Task<Reparaciones> AddObject(Reparaciones type)
    {
        _contexto.Reparaciones.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Reparaciones type)
    {
        var detalle = await _contexto.ReparacionesDetalle.Where(r => r.ReparacionId == type.ReparacionId).ToListAsync();
        foreach (var item in detalle)
        {
            var prod = await _contexto.Productos.FindAsync(item.ProductoId);
            prod!.Cantidad += item.CantidadUsada;
            _contexto.Entry(prod).State = EntityState.Modified;
        }

        if (type.EstadoId != 4)
        {
            foreach (var item in type.ReparacionDetalle)
            {
                var prod = await _contexto.Productos.FindAsync(item.ProductoId);
                prod!.Cantidad -= item.CantidadUsada;
                _contexto.Entry(prod).State = EntityState.Modified;
            }
        }
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var repa = await _contexto.Reparaciones.FindAsync(id);
        if (repa == null)
            return false;
        await _contexto.ReparacionesDetalle.Where(r => r.ReparacionId == id).ExecuteDeleteAsync();
        _contexto.Reparaciones.Remove(repa);
        await _contexto.SaveChangesAsync();
        return true;
    }
    public Task<List<Reparaciones>> GetObjectByCondition(Expression<Func<Reparaciones, bool>> expression)
    {
        return _contexto.Reparaciones.Include(d => d.ReparacionDetalle)
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
