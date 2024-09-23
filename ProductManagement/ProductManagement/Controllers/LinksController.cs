using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.DTOs;
using ProductManagement.Services;
using Raven.Client.Exceptions;

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
            if (linkDTO == null)
                return BadRequest("Link data is required.");

            try
            {
                await _linkService.AddLinkAsync(linkDTO);
                return CreatedAtAction(nameof(AddLink), new {id = linkDTO.Id}, linkDTO);
            }
            catch (ConflictException)
            {
                return Conflict("Link may already exist.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLink(int id)
        {
            try
            {
                var link = await _linkService.GetLinkByIdAsync(id);

                if (link == null)
                    return NotFound($"Link with id: {id} not found.");

                await _linkService.DeleteLinkAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
