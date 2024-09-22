using ProductManagement.Models.Entities;

namespace ProductManagement.Repositories
{
    public interface INomenklatureRepository
    {
        IEnumerable<Nomenklature> GetAll();
        Nomenklature GetById(int id);
        void Add(Nomenklature nomenklature);
        void Update(Nomenklature nomenklature);
        void Delete(Nomenklature nomenklature);
    }
}
