using HydraulicFix.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;

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
	public async Task<Configuraciones?> Search(int configuracionesId)
	{
		return await _contexto.Configuraciones.AsNoTracking().FirstOrDefaultAsync(a => a.ConfiguracionId == configuracionesId);
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
    public async Task<string> GuardarImagenYObtenerUrl(byte[] imagenBytes, NavigationManager navigationManager)
    {
        string nombreArchivo = $"imagen_{DateTime.Now.Ticks}.jpg";
        string rutaArchivo = Path.Combine("wwwroot", "boostrap", nombreArchivo);

        await File.WriteAllBytesAsync(rutaArchivo, imagenBytes);

        string urlImagen = $"{navigationManager.BaseUri}uploads/{nombreArchivo}";

        return urlImagen;
    }
    public async Task<Configuraciones> ObtenerConfiguracionActual()
    {

        var configuracionActual = new Configuraciones
        {
            NombreEmpresa = "HydraulicFix",
            Direccion = "Calle Primera",
            Nota = "Devoluciones hasta 3 días. Gracias por su compra",
            NFC = "11111111111111",
            Telefono = "809-244-6767"
        };

        return configuracionActual;
    }
}

