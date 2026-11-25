using IsakSiteApi.Dtos;
using IsakSiteApi.Enums;

namespace IsakSiteApi.Interfaces
{
    public interface IOwner
    {
        Task<OwnerDto?> GetOwner();
        Task<EOwner> CreateOwner(OwnerCreateDto dto);
        Task<EOwner> UpdateOwner(OwnerUpdateDto dto);
    }
}
