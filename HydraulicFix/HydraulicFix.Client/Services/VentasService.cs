using Shared.Interfaces;
using Shared.Models;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class VentasService(HttpClient _httpClient) : IHydraulic<Ventas>
{
    public async Task<List<Ventas>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/Ventas");
        if(response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<Ventas>>())!;
            
        }
        return null!;
    }

    public async Task<Ventas> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/Ventas/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Ventas>())!;

        }
        return null!;
    }

    public async Task<Ventas> AddObject(Ventas type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Ventas", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Ventas>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(Ventas type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Ventas/{type.VentaId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Ventas/{id}");
        return response.IsSuccessStatusCode;
    }
}
