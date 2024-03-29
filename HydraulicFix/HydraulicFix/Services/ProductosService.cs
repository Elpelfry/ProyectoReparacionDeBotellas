using HydraulicFix.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;

namespace HydraulicFix.Services;

public class ProductosService(ApplicationDbContext _contexto) : IServer<Productos>
{
    public async Task<Productos> GetObject(int id)
    {
        return (await _contexto.Productos.FindAsync(id))!;
    }

    public async Task<List<Productos>> GetAllObject()
    {
        return await _contexto.Productos.ToListAsync();
    }

    public async Task<Productos> AddObject(Productos type)
    {
        _contexto.Productos.Add(type);
        await _contexto.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Productos type)
    {
        _contexto.Entry(type).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Productos?> Search(int productoId)
    {
        return await _contexto.Productos.AsNoTracking().FirstOrDefaultAsync(a => a.ProductoId == productoId);
    }

    public async Task<bool> DeleteObject(int id)
    {
        var producto = await _contexto.Productos.FindAsync(id);
        if (producto == null)
        {
            return false;
        }
        _contexto.Productos.Remove(producto);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<string> Random()
    {
        const string caracteres = "123456789abcdefghijklmnopqrstuvwxyz?_";
        char[] codigo = new char[16];

        for (int i = 0; i < 16; i++)
        {
            codigo[i] = caracteres[new Random().Next(caracteres.Length)];
        }
        return new string(codigo);
    }


}
