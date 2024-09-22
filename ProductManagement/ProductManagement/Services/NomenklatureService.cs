using ProductManagement.DTOs;
using ProductManagement.Models.Entities;
using ProductManagement.Repositories;

namespace ProductManagement.Services
{
    public class NomenklatureService :INomenklatureService
    {
        private const int InitQuantity = 1;
        private readonly INomenklatureRepository _nomenklatureRepository;
        private readonly ILinkRepository _linkRepository;
        
        public NomenklatureService(INomenklatureRepository nomenklatureRepository, ILinkRepository linkRepository)
        {
            _nomenklatureRepository = nomenklatureRepository;
            _linkRepository = linkRepository;
        }

        public void AddNomenklature(NomenklatureDTO nomenklatureDTO)
        {
            var nomenklature = new Nomenklature
            {
                Name = nomenklatureDTO.Name,
                Price = nomenklatureDTO.Price
            };

            _nomenklatureRepository.Add(nomenklature);
        }

        public void DeleteNomenklatureById(int id)
        {
            var nomenklature = _nomenklatureRepository.GetById(id);

            if (nomenklature == null)
                return;

            _nomenklatureRepository.Delete(nomenklature);
        }

        public IEnumerable<NomenklatureDTO> GetAllNomenklatures()
        {
            var nomenklatures = _nomenklatureRepository.GetAll();

            return nomenklatures.Select(n => new NomenklatureDTO
            {
                Id = n.Id,
                Name = n.Name,
                Price = n.Price
            }).ToList();
        }

        public NomenklatureDTO GetNomenklatureById(int id)
        {
            var nomenklature = _nomenklatureRepository.GetById(id);
            
            if (nomenklature == null)
                return null;

            // Calculate the total price.
            // Start with a quantity of 1 for the top product.
            // 1 is stored as a const to avoid using "magic numbers" directly in code.
            var totalPrice = CalculateTotalPrice(nomenklature, InitQuantity);

            return new NomenklatureDTO
            {
                Id = nomenklature.Id,
                Name = nomenklature.Name,
                Price = nomenklature.Price
            };
        }

        private decimal CalculateTotalPrice(Nomenklature nomenklature, int quantity)
        {
            decimal totalPrice = nomenklature.Price * quantity;
            var childLinks = _linkRepository.GetByParentId(nomenklature.Id);

            // Calculate the total price for all child nomenklatures.
            foreach (var link in childLinks)
            {
                var childNomenklature = _nomenklatureRepository.GetById(link.NomenklatureId);

                if (childNomenklature != null)
                    totalPrice += CalculateTotalPrice(childNomenklature, link.Quantity);
            }

            return totalPrice;
        }

        public void UpdateNomenklature(int id, NomenklatureDTO nomenklatureDTO)
        {
            var nomenklature = _nomenklatureRepository.GetById(id);

            if (nomenklature == null)
                return;

            nomenklature.Name = nomenklatureDTO.Name;
            nomenklature.Price = nomenklature.Price;

            _nomenklatureRepository.Update(nomenklature);
        }
    }
}
