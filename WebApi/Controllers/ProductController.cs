using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var res = await _context.FullProductInfos.ToListAsync();
            return Ok(res);
        }
    }
}