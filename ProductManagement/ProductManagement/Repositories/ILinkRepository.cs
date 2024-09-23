using ProductManagement.Models.Entities;

namespace ProductManagement.Repositories
{
    public interface ILinkRepository
    {
        Task<IEnumerable<Link>> GetAllAsync();
        Task<Link> GetNomenklatureByIdAsync(int id);
        Task<Link> GetByIdAsync(int id);
        Task AddAsync(Link link);
        Task DeleteAsync(Link link);
        Task<IEnumerable<Link>> GetByParentIdAsync(int parentId);
    }
}
