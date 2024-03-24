using HydraulicFix.Client.Dto;
using Shared.Interfaces;

namespace HydraulicFix.Client.Service
{
    public class UsersService(HttpClient httpClient) : IHydraulicAsp<ApplicationUserDto>
    {
        public Task<ApplicationUserDto> AddObject(ApplicationUserDto type)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteObject(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUserDto>> GetAllObject()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> GetObject(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateObject(ApplicationUserDto type)
        {
            throw new NotImplementedException();
        }
    }
}
