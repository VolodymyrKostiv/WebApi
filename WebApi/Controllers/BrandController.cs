using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public BrandController(ILogger<BrandController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet(Name = "GetBrand")]
        public IEnumerable<Brand> Get()
        {
            return _context.Brands.ToArray();
        }
    }
}