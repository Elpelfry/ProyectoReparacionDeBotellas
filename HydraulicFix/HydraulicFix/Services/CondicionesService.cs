using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace HydraulicFix.Services;

public class CondicionesService(ApplicationDbContext _contexto) : IServer<Condiciones>
{

    public async Task<List<Condiciones>> GetAllObject()
    {
        return await _contexto.Condiciones.ToListAsync();
    }

    public Task<Condiciones> GetObject(int id)
    {
        return (_contexto.Condiciones.FirstOrDefaultAsync(x => x.CondicionId == id))!;
    }

    public Task<bool> UpdateObject(Condiciones type)
    {
        throw new NotImplementedException();
    }
    public Task<Condiciones> AddObject(Condiciones type)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteObject(int id)
    {
        throw new NotImplementedException();
    }
    public Task<List<Condiciones>> GetObjectByCondition(Expression<Func<Condiciones, bool>> expression)
    {
        return _contexto.Condiciones
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}