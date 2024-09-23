using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Models.Entities;

namespace ProductManagement.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LinkRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Link link)
        {
            await _dbContext.Links.AddAsync(link);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Link link)
        {
            _dbContext.Links.Remove(link);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Link>> GetAllAsync()
        {
            return await _dbContext.Links.ToListAsync();
        }

        public async Task<Link> GetNomenklatureByIdAsync(int id)
        {
            return await _dbContext.Links.FirstOrDefaultAsync(n => n.NomenklatureId == id);
        }

        public async Task<Link> GetByIdAsync(int id)
        {
            return await _dbContext.Links.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<Link>> GetByParentIdAsync(int parentId)
        {
            return await _dbContext.Links.Where(l => l.ParentId == parentId).ToListAsync();
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
