using ProductManagement.DTOs;

namespace ProductManagement.Services
{
    public interface ILinkService
    {
        IEnumerable<LinkDTO> GetAllLinks();
        LinkDTO GetLinkById(int id);
        void AddLink(LinkDTO linkDTO);
        void DeleteLink(int id);
    }
}
