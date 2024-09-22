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
        
        public void Add(Nomenklature nomenklature)
        {
            _dbContext.Nomenklatures.Add(nomenklature);
            _dbContext.SaveChanges();
        }

        public void Delete(Nomenklature nomenklature)
        {
            _dbContext.Nomenklatures.Remove(nomenklature);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Nomenklature> GetAll()
        {
            return _dbContext.Nomenklatures.ToList();
        }

        public Nomenklature GetById(int id)
        {
            return _dbContext.Nomenklatures.Find(id);
        }

        public void Update(Nomenklature nomenklature)
        {
            _dbContext.Nomenklatures.Update(nomenklature);
            _dbContext.SaveChanges();
        }
    }
}
