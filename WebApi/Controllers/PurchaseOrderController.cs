using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("api/purchaseOrders")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly ILogger<PurchaseOrderController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public PurchaseOrderController(ILogger<PurchaseOrderController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        public IEnumerable<PurchaseOrder> Get()
        {
            return _context.PurchaseOrders.ToArray();
        }
    }
}