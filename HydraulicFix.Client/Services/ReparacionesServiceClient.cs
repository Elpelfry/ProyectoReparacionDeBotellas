using Shared.Interfaces;
using Shared.Models;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class ReparacionesServiceClient(HttpClient _httpClient) : IClient<Reparaciones>
{
    public async Task<List<Reparaciones>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/Reparaciones");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<Reparaciones>>())!;
        }
        return null!;
    }

    public async Task<Reparaciones> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/Reparaciones/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Reparaciones>())!;
        }
        return null!;
    }

    public async Task<Reparaciones> AddObject(Reparaciones type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Reparaciones", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Reparaciones>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(Reparaciones type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Reparaciones/{type.ReparacionId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Reparaciones/{id}");
        return response.IsSuccessStatusCode;
    }
}
