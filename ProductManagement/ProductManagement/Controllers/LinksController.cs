using Microsoft.AspNetCore.Http;
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
        public IActionResult AddLink(LinkDTO linkDTO)
        {
            _linkService.AddLink(linkDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteLink(int id)
        {
            _linkService.DeleteLink(id);

            return Ok();
        }
    }
}
