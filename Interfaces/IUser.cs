using IsakSiteApi.Dtos;
using IsakSiteApi.Enums;
using IsakSiteApi.Models;

namespace IsakSiteApi.Interfaces
{
    public interface IUser
    {
        Task<EUser> CreateUser(UserCreateDto dto);
        string GenerateJwtToken(User user);
    }
}
