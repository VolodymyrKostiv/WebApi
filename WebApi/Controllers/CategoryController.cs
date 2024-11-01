using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var res = _context.Categories.ToArray();
            return Ok(res);
        }
    }
}