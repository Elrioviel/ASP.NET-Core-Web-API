using ProductManagement.DTOs;

namespace ProductManagement.Services
{
    public interface INomenklatureService
    {
        Task<IEnumerable<NomenklatureDTO>> GetAllNomenklaturesAsync();
        Task<NomenklatureDetailDTO> GetNomenklatureByIdAsync(int id);
        Task UpdateNomenklatureAsync(int id, NomenklatureDTO nomenklatureDTO);
        Task DeleteNomenklatureByIdAsync(int id);
        Task AddNomenklatureAsync(NomenklatureDTO nomenklatureDTO);
    }
}
