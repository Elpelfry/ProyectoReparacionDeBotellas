using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace HydraulicFix.Services;

public class ConfiguracionesService(ApplicationDbContext _contexto) : IServer<Configuraciones>
{
    public async Task<List<Configuraciones>> GetAllObject()
    {
       return await _contexto.Configuraciones.ToListAsync();
    }

    public async Task<Configuraciones> GetObject(int id)
    {
        return (await _contexto.Configuraciones.FindAsync(id))!;
    }

    public async Task<Configuraciones> AddObject(Configuraciones type)
    {
        _contexto.Configuraciones.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Configuraciones type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var configuracion = await _contexto.Configuraciones.FindAsync(id);
        if (configuracion == null)
        {
            return false;
        }
        _contexto.Configuraciones.Remove(configuracion);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<List<Configuraciones>> GetObjectByCondition(Expression<Func<Configuraciones, bool>> expression)
    {
        return await _contexto.Configuraciones
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}

