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
            if (nomenklatureDTO == null)
                return BadRequest("Nomenklature data is required.");

            try
            {
                await _nomenklatureService.AddNomenklatureAsync(nomenklatureDTO);
                return CreatedAtAction(nameof(GetNomenklatureById), new { id = nomenklatureDTO.Id }, nomenklatureDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNomenklature(int id, NomenklatureDTO nomenklatureDTO)
        {
            if (nomenklatureDTO == null)
                return BadRequest("Nomenklature data is required.");

            try
            {
                await _nomenklatureService.UpdateNomenklatureAsync(id, nomenklatureDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomenklature(int id)
        {
            try
            {
                var nomenklature = await _nomenklatureService.GetNomenklatureByIdAsync(id);

                if (nomenklature == null)
                    return NotFound($"Nomenklature with id: {id} not found.");

                await _nomenklatureService.DeleteNomenklatureByIdAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
