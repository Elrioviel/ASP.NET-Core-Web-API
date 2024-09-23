using ProductManagement.DTOs;

namespace ProductManagement.Services
{
    public interface INomenklatureService
    {
        IEnumerable<NomenklatureDTO> GetAllNomenklatures();
        NomenklatureDetailDTO GetNomenklatureById(int id);
        void UpdateNomenklature(int id, NomenklatureDTO nomenklatureDTO);
        void DeleteNomenklatureById(int id);
        void AddNomenklature(NomenklatureDTO nomenklatureDTO);
    }
}
