using Microsoft.AspNetCore.Identity;
using Shared.Interfaces;

namespace HydraulicFix.Client.Service;

public class RolesService(HttpClient httpClient) : IHydraulicAsp<IdentityRole>
{
    public Task<IdentityRole> AddObject(IdentityRole type)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteObject(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<IdentityRole>> GetAllObject()
    {
        throw new NotImplementedException();
    }

    public Task<IdentityRole> GetObject(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateObject(IdentityRole type)
    {
        throw new NotImplementedException();
    }
}
