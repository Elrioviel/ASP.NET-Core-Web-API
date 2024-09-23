using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Models.Entities;

namespace ProductManagement.Repositories
{
    public class NomenklatureRepository : INomenklatureRepository
    {
        private readonly ApplicationDbContext _dbContext;
        
        public NomenklatureRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task AddAsync(Nomenklature nomenklature)
        {
            _dbContext.Nomenklatures.AddAsync(nomenklature);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Nomenklature nomenklature)
        {
            _dbContext.Nomenklatures.Remove(nomenklature);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Nomenklature>> GetAllAsync()
        {
            return await _dbContext.Nomenklatures.ToListAsync();
        }

        public async Task<Nomenklature> GetByIdAsync(int id)
        {
            return await _dbContext.Nomenklatures.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(Nomenklature nomenklature)
        {
            _dbContext.Nomenklatures.Update(nomenklature);
            await SaveChangesAsync();
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error updating database", ex);
            }
        }
    }
}
