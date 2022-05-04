using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
//    [ApiController]
//    [Route("api/supplyOrders")]
    public class SupplyOrderController : ControllerBase
    {
        private readonly ILogger<SupplyOrderController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public SupplyOrderController(ILogger<SupplyOrderController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        public IEnumerable<SupplyOrder> Get()
        {
            return _context.SupplyOrders.ToArray();
        }
    }
}