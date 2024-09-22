using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data;
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
        public IActionResult GetAllNomenklatures()
        {
            var allNomenklatures = _nomenklatureService.GetAllNomenklatures();

            return Ok(allNomenklatures);
        }

        [HttpGet("{id}")]
        public IActionResult GetNomenklatureById(int id)
        {
            var nomenklature = _nomenklatureService.GetNomenklatureById(id);

            if (nomenklature == null)
                return NotFound();

            return Ok(nomenklature);
        }

        [HttpPost]
        public IActionResult AddNomenklature(NomenklatureDTO nomenklatureDTO)
        {
            _nomenklatureService.AddNomenklature(nomenklatureDTO);
            
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNomenklature(int id, NomenklatureDTO nomenklatureDTO)
        {
            _nomenklatureService.UpdateNomenklature(id, nomenklatureDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNomenklature(int id)
        {
            _nomenklatureService.DeleteNomenklatureById(id);

            return Ok();
        }
    }
}
