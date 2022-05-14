using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public BrandController(ILogger<BrandController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var res = _context.Brands.Where(x => x.BrandId == id).FirstOrDefault();

            _context.Brands.Remove(res);    
            _context.SaveChanges();

            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var res = _context.Brands.ToArray();
            return Ok(res);
        }
    }
}