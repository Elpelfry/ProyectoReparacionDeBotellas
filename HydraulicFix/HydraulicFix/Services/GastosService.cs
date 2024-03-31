using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace HydraulicFix.Services;

public class GastosService(ApplicationDbContext _contexto) : IServer<Gastos>
{
    public async Task<List<Gastos>> GetAllObject()
    {
        return await _contexto.Gastos.ToListAsync();
    }

    public async Task<Gastos> GetObject(int id)
    {
        return (await _contexto.Gastos.FirstOrDefaultAsync(a => a.GastoId == id))!;
    }
    public async Task<bool> UpdateObject(Gastos type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<Gastos> AddObject(Gastos type)
    {
        _contexto.Gastos.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var gasto = await _contexto.Gastos.FindAsync(id);
        if (gasto == null)
        {
            return false;
        }
        _contexto.Gastos.Remove(gasto);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<Gastos>> GetObjectByCondition(Expression<Func<Gastos, bool>> expression)
    {
        return await _contexto.Gastos
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
