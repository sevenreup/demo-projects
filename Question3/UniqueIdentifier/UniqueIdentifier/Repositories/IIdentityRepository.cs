using UniqueIdentifier.DTOs;

namespace UniqueIdentifier.Repositories
{
    public interface IIdentityRepository
    {
        Task<IdentityDTO> CreateIdentifier();
        Task<bool> DisableIdentifier(string id);
    }
}