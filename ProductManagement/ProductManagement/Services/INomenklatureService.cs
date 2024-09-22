using ProductManagement.DTOs;

namespace ProductManagement.Services
{
    public interface INomenklatureService
    {
        IEnumerable<NomenklatureDTO> GetAllNomenklatures();
        NomenklatureDTO GetNomenklatureById(int id);
        void UpdateNomenklature(int id, NomenklatureDTO nomenklatureDTO);
        void DeleteNomenklatureById(int id);
    }
}
