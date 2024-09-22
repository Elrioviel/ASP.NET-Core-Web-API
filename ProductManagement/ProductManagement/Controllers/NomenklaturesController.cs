using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data;

namespace ProductManagement.Controllers
{
    [Route("api/nomenklatures")]
    [ApiController]
    public class NomenklaturesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public NomenklaturesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllNomenklatures()
        {
            var allNomenklatures = _dbContext.Nomenklatures.ToList();

            return Ok(allNomenklatures);
        }

        [HttpGet("{id}")]
        public IActionResult GetNomenklatureById([FromRoute] int id)
        {

        }
    }
}
