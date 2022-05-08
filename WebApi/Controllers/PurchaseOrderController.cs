using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/purchaseOrders")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly ILogger<PurchaseOrderController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public PurchaseOrderController(ILogger<PurchaseOrderController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrders(int employeeID)
        {
            if (employeeID < 1)
            {
                return BadRequest("Invalid employee ID");
            }

            try
            {
                var orders = _context.PurchaseOrders.Where(order => order.EmployeeId == employeeID).Select(x => x).ToList();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePurchaseOrder()
        {
            //bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
            //var bodyText = bodyStream.ReadToEnd();
            //var input = Newtonsoft.Json.JsonConvert.DeserializeObject<PurchaseOrder>(order);
            return Ok();
        }
    }
}