using Microsoft.AspNetCore.Mvc;
using ProductManagement.DTOs;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    [Route("api/nomenklatures")]
    [ApiController]
    public class NomenklaturesController : ControllerBase
    {
        private readonly INomenklatureService _nomenklatureService;
        public NomenklaturesController(INomenklatureService nomenklatureService)
        {
            _nomenklatureService = nomenklatureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNomenklatures()
        {
            var allNomenklatures = await _nomenklatureService.GetAllNomenklaturesAsync();

            return Ok(allNomenklatures);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNomenklatureById(int id)
        {
            var nomenklature = await _nomenklatureService.GetNomenklatureByIdAsync(id);

            if (nomenklature == null)
                return NotFound();

            return Ok(nomenklature);
        }

        [HttpPost]
        public async Task<IActionResult> AddNomenklature(NomenklatureDTO nomenklatureDTO)
        {
            await _nomenklatureService.AddNomenklatureAsync(nomenklatureDTO);
            
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNomenklature(int id, NomenklatureDTO nomenklatureDTO)
        {
            await _nomenklatureService.UpdateNomenklatureAsync(id, nomenklatureDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomenklature(int id)
        {
            await _nomenklatureService.DeleteNomenklatureByIdAsync(id);

            return Ok();
        }
    }
}
