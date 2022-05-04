using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class PersonalDatumController : ControllerBase
    {
        private readonly ILogger<PersonalDatumController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public PersonalDatumController(ILogger<PersonalDatumController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        public IEnumerable<PersonalDatum> Get()
        {
            return _context.PersonalData.ToArray();
        }
    }
}