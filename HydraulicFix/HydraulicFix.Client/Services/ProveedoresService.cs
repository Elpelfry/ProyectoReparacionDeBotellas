using Shared.Interfaces;
using Shared.Models;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class ProveedoresService(HttpClient _httpClient) : IHydraulic<Proveedores>
{
    public async Task<List<Proveedores>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/Proveedores");
        if(response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<Proveedores>>())!;
        }
        return null!;
    }

    public async Task<Proveedores> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/Proveedores/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Proveedores>())!;
        }
        return null!;
    }

    public async Task<Proveedores> AddObject(Proveedores type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Proveedores", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Proveedores>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(Proveedores type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Proveedores/{type.ProveedorId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Proveedores/{id}");
        return response.IsSuccessStatusCode;
    }
}
