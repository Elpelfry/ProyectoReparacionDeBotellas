using Shared.Interfaces;
using Shared.Models;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class CategoriaProductosService(HttpClient _httpClient) : IHydraulic<CategoriaProductos>
{
    public async Task<List<CategoriaProductos>> GetAllObject()
    {
        var response = await _httpClient.GetAsync("api/CategoriaProductos");
        if(response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<CategoriaProductos>>())!;
        }
        return null!;
    }

    public async Task<CategoriaProductos> GetObject(int id)
    {
        var response = await _httpClient.GetAsync($"api/CategoriaProductos/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<CategoriaProductos>())!;
        }
        return null!;
    }

    public async Task<CategoriaProductos> AddObject(CategoriaProductos type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/CategoriaProductos", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<CategoriaProductos>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(CategoriaProductos type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/CategoriaProductos/{type.CategoriaId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/CategoriaProductos/{id}");
        return response.IsSuccessStatusCode;
    }
}
