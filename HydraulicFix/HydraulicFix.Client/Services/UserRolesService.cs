using Microsoft.AspNetCore.Identity;
using Shared.Interfaces;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class UserRolesService(HttpClient _httpClient) : IHydraulicAsp<IdentityUserRole<string>>
{
    public async Task<List<IdentityUserRole<string>>> GetAllObject()
    {
        var roles = await _httpClient.GetAsync("api/UserRoles");
        if(roles.IsSuccessStatusCode)
        {
            return (await roles.Content.ReadFromJsonAsync <List<IdentityUserRole<string>>>())!;
        }
        return null!;
    }

    public async Task<IdentityUserRole<string>> GetObject(string id)
    {
        var role = await _httpClient.GetAsync("api/UserRoles");
        if (role.IsSuccessStatusCode)
        {
            return (await role.Content.ReadFromJsonAsync<IdentityUserRole<string>>())!;
        }
        return null!;
    }

    public async Task<IdentityUserRole<string>> AddObject(IdentityUserRole<string> type)
    {
        var response = await _httpClient.PostAsJsonAsync("api/UserRoles", type);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<IdentityUserRole<string>>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(IdentityUserRole<string> type)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/UserRoles/{type.UserId}", type);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(string id)
    {
        var response = await _httpClient.DeleteAsync($"api/UserRoles/{id}");
        return response.IsSuccessStatusCode;
    }
}

