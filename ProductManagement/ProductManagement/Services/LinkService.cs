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

        public void AddLink(LinkDTO linkDTO)
        {
            var link = new Link
            {
                NomenklatureId = linkDTO.NomenklatureId,
                ParentId = linkDTO.ParentId,
                Quantity = linkDTO.Quantity
            };

            _linkRepository.Add(link);
        }

        public void DeleteLink(int id)
        {
            var link = _linkRepository.GetById(id);

            if (link == null)
                return;

            _linkRepository.Delete(link);
        }

        public IEnumerable<LinkDTO> GetAllLinks()
        {
            var links = _linkRepository.GetAll();

            return links.Select(l => new LinkDTO
            {
                Id = l.Id,
                NomenklatureId = l.NomenklatureId,
                ParentId = l.ParentId,
                Quantity = l.Quantity
            }).ToList();
        }

        public LinkDTO GetLinkById(int id)
        {
            var link = _linkRepository.GetById(id);
            
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

        public void UpdateLink(int id, LinkDTO linkDTO)
        {
            var link = _linkRepository.GetById(id);

            if (link == null)
                return;

            link.NomenklatureId = linkDTO.NomenklatureId;
            link.ParentId = linkDTO.ParentId;
            link.Quantity = linkDTO.Quantity;

            _linkRepository.Update(link);
        }
    }
}
