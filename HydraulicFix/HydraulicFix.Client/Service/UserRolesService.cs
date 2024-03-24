using HydraulicFix.Client.Dto;
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces;

namespace HydraulicFix.Client.Service;

public class UserRolesService(HttpClient httpClient) : IHydraulicAsp<IdentityUserRole<string>>
{
    public Task<IdentityUserRole<string>> AddObject(IdentityUserRole<string> type)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteObject(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<IdentityUserRole<string>>> GetAllObject()
    {
        throw new NotImplementedException();
    }

    public Task<IdentityUserRole<string>> GetObject(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateObject(IdentityUserRole<string> type)
    {
        throw new NotImplementedException();
    }
}

