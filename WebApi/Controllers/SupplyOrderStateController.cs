using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class SupplyOrderStateController : ControllerBase
    {
        private readonly ILogger<SupplyOrderStateController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public SupplyOrderStateController(ILogger<SupplyOrderStateController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        public IEnumerable<SupplyOrderState> Get()
        {
            return _context.SupplyOrderStates.ToArray();
        }
    }
}