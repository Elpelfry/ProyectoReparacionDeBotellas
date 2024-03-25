using Shared.Interfaces;
using Shared.Models;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class ConfiguracionesService(HttpClient _httpClient) : IHydraulic<Configuraciones>
{
    public async Task<List<Configuraciones>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/Configuraciones");
        if(response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<Configuraciones>>())!;
        }
        return null!;
    }

    public async Task<Configuraciones> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/Configuraciones/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Configuraciones>())!;
        }
        return null!;
    }

    public async Task<Configuraciones> AddObject(Configuraciones type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Configuraciones", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Configuraciones>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(Configuraciones type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Configuraciones/{type.ConfiguracionId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Configuraciones/{id}");
        return response.IsSuccessStatusCode;
    }
}
