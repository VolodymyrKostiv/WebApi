using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class LoginDatumController : ControllerBase
    {
        private readonly ILogger<LoginDatumController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public LoginDatumController(ILogger<LoginDatumController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        public IEnumerable<LoginDatum> Get()
        {
            return _context.LoginData.ToArray();
        }
    }
}