using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace HydraulicFix.Services;

public class AbonosService(ApplicationDbContext _contexto) : IServer<Abonos>
{
    public async Task<List<Abonos>> GetAllObject()
    {
        return await _contexto.Abonos.Include(a => a.AbonoDetalle).ToListAsync();
    }

    public async Task<Abonos> GetObject(int id)
    {
        return (await _contexto.Abonos.Include(a => a.AbonoDetalle).FirstOrDefaultAsync(a => a.AbonoId == id))!;
    }

    public async Task<Abonos> AddObject(Abonos type)
    {
        _contexto.Abonos.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Abonos type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var abono = await _contexto.Abonos.FindAsync(id);
        if (abono == null)
            return false;
        await _contexto.AbonosDetalle.Where(x => x.AbonoId == id).ExecuteDeleteAsync();
        _contexto.Abonos.Remove(abono);
       return await _contexto.SaveChangesAsync() > 0;  
    }

    public async Task<List<Abonos>> GetObjectByCondition(Expression<Func<Abonos, bool>> expression)
    {
        return await _contexto.Abonos.Include(a => a.AbonoDetalle).
            AsNoTracking().
            Where(expression)
                .ToListAsync();
    }
}