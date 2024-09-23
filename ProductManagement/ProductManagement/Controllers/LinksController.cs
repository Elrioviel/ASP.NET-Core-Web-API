using Microsoft.AspNetCore.Mvc;
using ProductManagement.DTOs;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    [Route("api/nomenklatures/link")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly ILinkService _linkService;

        public LinksController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLink(LinkDTO linkDTO)
        {
            await _linkService.AddLinkAsync(linkDTO);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLink(int id)
        {
            await _linkService.DeleteLinkAsync(id);

            return Ok();
        }
    }
}
