using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet(Name = "GetCategory")]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToArray();
        }
    }
}