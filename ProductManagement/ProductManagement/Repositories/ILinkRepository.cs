using ProductManagement.Models.Entities;

namespace ProductManagement.Repositories
{
    public interface ILinkRepository
    {
        IEnumerable<Link> GetAll();
        Link GetById(int id);
        void Add(Link link);
        void Update(Link link);
        void Delete(Link link);
    }
}
