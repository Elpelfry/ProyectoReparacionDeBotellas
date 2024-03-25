using Shared.Interfaces;
using Shared.Models;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class AbonosService(HttpClient _httpClient) : IHydraulic<Abonos>
{
    public async Task<List<Abonos>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/Abonos");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<Abonos>>())!;
        }
        return null!;
    }

    public async Task<Abonos> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/Abonos/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Abonos>())!;
        }
        return null!;
    }

    public async Task<Abonos> AddObject(Abonos type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Abonos", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Abonos>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(Abonos type)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Abonos", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Abonos/{id}");
        return response.IsSuccessStatusCode;
    }
}
