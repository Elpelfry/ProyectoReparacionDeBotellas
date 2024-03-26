using Microsoft.AspNetCore.Identity;
using Shared.Interfaces;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class RolesServiceClient(HttpClient _httpClient) : IClientAsp<IdentityRole>
{
    public async Task<List<IdentityRole>> GetAllObject()
    {
        var roles = await _httpClient.GetAsync("api/Roles");
        if (roles.IsSuccessStatusCode)
        {
            return (await roles.Content.ReadFromJsonAsync<List<IdentityRole>>())!;
        }
        return null!;
    }

    public async Task<IdentityRole> GetObject(string id)
    {
        var response = await _httpClient.GetAsync($"api/Roles/{id}");
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<IdentityRole>())!;
        }
        return null!;
    }

    public async Task<IdentityRole> AddObject(IdentityRole type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Roles", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<IdentityRole>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(IdentityRole type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Roles/{type.Id}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(string id)
    {
        var response = await _httpClient.DeleteAsync($"api/Roles/{id}");
        return response.IsSuccessStatusCode;
    }
}
