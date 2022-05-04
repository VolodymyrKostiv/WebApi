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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsOnStorage(int storageId)
        {
            //try
            //{
            //    string storedProcedure = "Exec SelectProductsFromStore " +
            //        "@EmployeeId = " + employeeId;
            //    var result = await _context.Products.FromSqlRaw(storedProcedure).ToListAsync();
            //    return Ok(result);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            return Ok();
        }

        [HttpGet("employee/{id}/")]
        public async Task<IActionResult> GetProductsOnStorageByEmployee(int employeeId)
        {
            if (employeeId < 1)
            {
                return BadRequest("Invalid emplpoyee Id");
            }
            try
            {
                string storedProcedure = "EXEC SelectProductsFromStore @EmployeeId = " + employeeId;
                string connectionString = "Server=localhost;Database=CourseWork_PlumbingStore;Trusted_Connection=True;";
                //var dt = new DataTable();

                //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                //{
                //    using (var command = new SqlCommand(storedProcedure, sqlConnection))
                //    {
                //        command.CommandType = System.Data.CommandType.StoredProcedure;

                //        sqlConnection.Open();

                //        dt.Load(command.ExecuteReader());
                //    }
                //}

                //var result = await _context.Products.FromSqlRaw(storedProcedure).ToListAsync();
                //return Ok(dt);
                //_context.Database.
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class StorageRes
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }   
    }
}