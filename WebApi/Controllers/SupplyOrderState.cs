using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/supplyOrderStates")]
    public class SupplyOrderStates : ControllerBase
    {
        private readonly ILogger<SupplyOrderStates> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public SupplyOrderStates(ILogger<SupplyOrderStates> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            var res = _context.SupplyOrderStates.ToArray();
            return Ok(res);
        }
    }
}