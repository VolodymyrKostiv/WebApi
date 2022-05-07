using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/storages")]
    public class StorageController : ControllerBase
    {
        private readonly ILogger<StorageController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public StorageController(ILogger<StorageController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetProductsOnStorageByEmployee(int employeeID)
        {
            if (employeeID < 1)
            {
                return BadRequest("Invalid employee ID");
            }

            try
            {
                string storedProcedure = "EXEC SelectProductsFromStore @EmployeeID = " + employeeID;
                var res = _context.ShopStorageProducts.FromSqlRaw(storedProcedure).ToList();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}