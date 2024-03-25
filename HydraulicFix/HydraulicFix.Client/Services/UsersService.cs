using Shared.Dto;
using Shared.Interfaces;
using System.Net.Http.Json;

namespace HydraulicFix.Client.Services;

public class UsersService(HttpClient _httpClient) : IHydraulicAsp<ApplicationUserDto>
{
    public async Task<List<ApplicationUserDto>> GetAllObject()
    {
        var user = await _httpClient.GetAsync("api/Users");
        if(user.IsSuccessStatusCode)
        {
            return (await user.Content.ReadFromJsonAsync<List<ApplicationUserDto>>())!;
        }
        return null!;
    }

    public async Task<ApplicationUserDto> GetObject(string id)
    {
        var user = await _httpClient.GetAsync($"api/Users/{id}");
        if (user.IsSuccessStatusCode)
        {
            return (await user.Content.ReadFromJsonAsync<ApplicationUserDto>())!;
        }
        return null!;
    }

    public async Task<ApplicationUserDto> AddObject(ApplicationUserDto type)
    {
        var user = await _httpClient.PostAsJsonAsync("api/Users", type);
        if (user.IsSuccessStatusCode)
        {
            return (await user.Content.ReadFromJsonAsync<ApplicationUserDto>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateObject(ApplicationUserDto type)
    {
        var user = await _httpClient.PutAsJsonAsync($"api/Users/{type.Id}", type);
        return user.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(string id)
    {
        var user = await _httpClient.DeleteAsync($"api/Users/{id}");
        return user.IsSuccessStatusCode;
    }
}
