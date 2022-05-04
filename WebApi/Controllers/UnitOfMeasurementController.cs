using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class UnitOfMeasurementController : ControllerBase
    {
        private readonly ILogger<UnitOfMeasurementController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public UnitOfMeasurementController(ILogger<UnitOfMeasurementController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        public IEnumerable<UnitOfMeasurement> Get()
        {
            return _context.UnitOfMeasurements.ToArray();
        }
    }
}