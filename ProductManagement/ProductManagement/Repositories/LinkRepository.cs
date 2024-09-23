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

        public void Add(Link link)
        {
            _dbContext.Links.Add(link);
            _dbContext.SaveChanges();
        }

        public void Delete(Link link)
        {
            _dbContext.Links.Remove(link);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Link> GetAll()
        {
            return _dbContext.Links.ToList();
        }

        public Link GetById(int id)
        {
            return _dbContext.Links.FirstOrDefault(n => n.NomenklatureId == id);
        }

        public IEnumerable<Link> GetByParentId(int parentId)
        {
            return _dbContext.Links.Where(l => l.ParentId == parentId).ToList();
        }
    }
}
