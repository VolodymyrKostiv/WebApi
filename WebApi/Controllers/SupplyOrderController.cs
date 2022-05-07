using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("api/supplyOrder")]
    public class SupplyOrderController : ControllerBase
    {
        private readonly ILogger<SupplyOrderController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public SupplyOrderController(ILogger<SupplyOrderController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplyOrdersByEmployee(int employeeID)
        {
            if (employeeID < 1)
            {
                return BadRequest("Invalid employee ID");
            }

            try
            {
                string storedProcedure = "EXEC SelectProductsFromStore @EmployeeID = " + employeeID;
                //var res = _context.ShopStorageProducts.FromSqlRaw(storedProcedure).ToList();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}