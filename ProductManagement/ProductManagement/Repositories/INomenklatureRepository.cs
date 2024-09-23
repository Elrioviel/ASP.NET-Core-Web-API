using ProductManagement.Models.Entities;

namespace ProductManagement.Repositories
{
    public interface INomenklatureRepository
    {
        Task<IEnumerable<Nomenklature>> GetAllAsync();
        Task<Nomenklature> GetByIdAsync(int id);
        Task AddAsync(Nomenklature nomenklature);
        Task UpdateAsync(Nomenklature nomenklature);
        Task DeleteAsync(Nomenklature nomenklature);
    }
}
