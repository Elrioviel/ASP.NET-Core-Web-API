using ProductManagement.DTOs;
using ProductManagement.Models.Entities;
using ProductManagement.Repositories;

namespace ProductManagement.Services
{
    public class NomenklatureService : INomenklatureService
    {
        private const int InitQuantity = 1;
        private readonly INomenklatureRepository _nomenklatureRepository;
        private readonly ILinkRepository _linkRepository;

        public NomenklatureService(INomenklatureRepository nomenklatureRepository, ILinkRepository linkRepository)
        {
            _nomenklatureRepository = nomenklatureRepository;
            _linkRepository = linkRepository;
        }

        public async Task AddNomenklatureAsync(NomenklatureDTO nomenklatureDTO)
        {
            var nomenklature = new Nomenklature
            {
                Name = nomenklatureDTO.Name,
                Price = nomenklatureDTO.Price
            };

            await _nomenklatureRepository.AddAsync(nomenklature);
        }

        public async Task DeleteNomenklatureByIdAsync(int id)
        {
            var nomenklature = await _nomenklatureRepository.GetByIdAsync(id);

            if (nomenklature == null)
                return;
            // Delete child link first.
            DeleteChildLinksAsync(id);

            // Delete parent nomenklature.
            await _nomenklatureRepository.DeleteAsync(nomenklature);
        }

        private async Task DeleteChildLinksAsync(int parentId)
        {
            var childLinks = await _linkRepository.GetByParentIdAsync(parentId);
            
            // Ensure cascade delete from link where nomenklature is parent.
            foreach (var link in childLinks)
            {
                await _linkRepository.DeleteAsync(link);
            }
        }

        public async Task<IEnumerable<NomenklatureDTO>> GetAllNomenklaturesAsync()
        {
            var nomenklatures = await _nomenklatureRepository.GetAllAsync();

            return nomenklatures.Select(n => new NomenklatureDTO
            {
                Id = n.Id,
                Name = n.Name,
                Price = n.Price
            }).ToList();
        }

        public async Task<NomenklatureDetailDTO> GetNomenklatureByIdAsync(int id)
        {
            var nomenklature = await _nomenklatureRepository.GetByIdAsync(id);

            if (nomenklature == null)
                return null;

            var currentLink = await _linkRepository.GetNomenklatureByIdAsync(nomenklature.Id);

            // If the product has no parent, start with a quantity of 1 for the top product.
            // 1 is stored as a const to avoid using "magic numbers" directly in code.
            var initialQuantity = currentLink?.Quantity ?? InitQuantity;

            // Calculate the total price.
            var totalPrice = await CalculateTotalPriceAsync(nomenklature, initialQuantity);

            return new NomenklatureDetailDTO
            {
                Id = nomenklature.Id,
                Name = nomenklature.Name,
                Price = nomenklature.Price,
                TotalPrice = totalPrice
            };
        }

        private async Task<decimal> CalculateTotalPriceAsync(Nomenklature nomenklature, int quantity)
        {
            decimal childTotalPrice = 0;
            var childLinks = await _linkRepository.GetByParentIdAsync(nomenklature.Id);

            // Calculate the total price for all child nomenklatures.
            foreach (var link in childLinks)
            {
                var childNomenklature = await _nomenklatureRepository.GetByIdAsync(link.NomenklatureId);

                if (childNomenklature != null)
                    childTotalPrice += await CalculateTotalPriceAsync(childNomenklature, link.Quantity);
            }

            // Return total price: (nomenklature price + childTotalPrice) * quantity.
            return (nomenklature.Price + childTotalPrice) * quantity;
        }

        public async Task UpdateNomenklatureAsync(int id, NomenklatureDTO nomenklatureDTO)
        {
            var nomenklature = await _nomenklatureRepository.GetByIdAsync(id);

            if (nomenklature == null)
                return;

            nomenklature.Name = nomenklatureDTO.Name;
            nomenklature.Price = nomenklatureDTO.Price;

            await _nomenklatureRepository.UpdateAsync(nomenklature);
        }
    }
}
