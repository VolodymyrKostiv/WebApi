using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public SupplierController(ILogger<SupplierController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        public IEnumerable<Supplier> Get()
        {
            return _context.Suppliers.ToArray();
        }
    }
}