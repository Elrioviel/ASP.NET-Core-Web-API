using ProductManagement.DTOs;
using ProductManagement.Repositories;

namespace ProductManagement.Services
{
    public class NomenklatureService :INomenklatureService
    {
        private readonly INomenklatureRepository _nomenklatureRepository;
        
        public NomenklatureService(INomenklatureRepository nomenklatureRepository)
        {
            _nomenklatureRepository = nomenklatureRepository;
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

            return new NomenklatureDTO
            {
                Id = nomenklature.Id,
                Name = nomenklature.Name,
                Price = nomenklature.Price
            };
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
