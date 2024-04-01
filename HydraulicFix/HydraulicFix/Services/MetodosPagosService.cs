using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace HydraulicFix.Services;

public class MetodosPagosService(ApplicationDbContext _contexto) : IServer<MetodoPagos>
{

    public async Task<List<MetodoPagos>> GetAllObject()
    {
        return await _contexto.MetodoPagos.ToListAsync();
    }

    public Task<MetodoPagos> GetObject(int id)
    {
        return (_contexto.MetodoPagos.FirstOrDefaultAsync(x => x.MetodoPagoId == id))!;
    }

    public Task<bool> UpdateObject(MetodoPagos type)
    {
        throw new NotImplementedException();
    }
    public Task<MetodoPagos> AddObject(MetodoPagos type)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteObject(int id)
    {
        throw new NotImplementedException();
    }
    public Task<List<MetodoPagos>> GetObjectByCondition(Expression<Func<MetodoPagos, bool>> expression)
    {
        return _contexto.MetodoPagos
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
