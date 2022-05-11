using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/suppliers")]
    public class SupplierController : ControllerBase
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly IMapper _mapper;
        private readonly CourseWork_PlumbingStoreContext _context;

        public SupplierController(ILogger<SupplierController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var suppliers = _context.Suppliers.ToList();
            var res = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(suppliers);
            return Ok(res);
        }
    }
}