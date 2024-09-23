using ProductManagement.DTOs;

namespace ProductManagement.Services
{
    public interface ILinkService
    {
        Task <IEnumerable<LinkDTO>> GetAllLinksAsync();
        Task<LinkDTO> GetLinkByIdAsync(int id);
        Task AddLinkAsync(LinkDTO linkDTO);
        Task DeleteLinkAsync(int id);
    }
}
