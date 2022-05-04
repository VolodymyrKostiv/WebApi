using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly ILogger<EmployeeTypeController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public EmployeeTypeController(ILogger<EmployeeTypeController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet(Name = "GetEmployeeType")]
        public IEnumerable<EmployeeType> Get()
        {
            return _context.EmployeeTypes.ToArray();
        }
    }
}