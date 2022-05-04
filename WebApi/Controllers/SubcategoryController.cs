using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class SubcategoryController : ControllerBase
    {
        private readonly ILogger<SubcategoryController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public SubcategoryController(ILogger<SubcategoryController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        public IEnumerable<Subcategory> Get()
        {
            return _context.Subcategories.ToArray();
        }
    }
}