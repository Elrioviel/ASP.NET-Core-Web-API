using ProductManagement.DTOs;
using ProductManagement.Models.Entities;
using ProductManagement.Repositories;

namespace ProductManagement.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepository;

        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task AddLinkAsync(LinkDTO linkDTO)
        {
            var link = new Link
            {
                NomenklatureId = linkDTO.NomenklatureId,
                ParentId = linkDTO.ParentId,
                Quantity = linkDTO.Quantity
            };

            await _linkRepository.AddAsync(link);
        }

        public async Task DeleteLinkAsync(int id)
        {
            var link = await _linkRepository.GetByIdAsync(id);

            if (link == null)
                return;

            await _linkRepository.DeleteAsync(link);
        }

        public async Task<IEnumerable<LinkDTO>> GetAllLinksAsync()
        {
            var links = await _linkRepository.GetAllAsync();

            return links.Select(l => new LinkDTO
            {
                Id = l.Id,
                NomenklatureId = l.NomenklatureId,
                ParentId = l.ParentId,
                Quantity = l.Quantity
            }).ToList();
        }

        public async Task<LinkDTO> GetLinkByIdAsync(int id)
        {
            var link = await _linkRepository.GetNomenklatureByIdAsync(id);
            
            if (link == null)
                return null;

            return new LinkDTO
            {
                Id = link.Id,
                NomenklatureId = link.NomenklatureId,
                ParentId = link.ParentId,
                Quantity = link.Quantity
            };
        }
    }
}
