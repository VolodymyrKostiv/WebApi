using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/authentification")]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet]
        public async Task<IActionResult> Login(string username, string password)
        {
            var login = _context.LoginData.Where(x => x.LoginName == username).FirstOrDefault();
            if (login == null || login.Password != password)
            {
                return BadRequest("Bad login or password");
            }
            else
            {
                var user = _context.Employees
                    .Include(x => x.EmployeeType)
                    .Include(x => x.Shop)
                    .Include(x => x.PersonalDatum)
                    .Where(x => x.EmployeeId == login.EmployeeId)
                    .FirstOrDefault();
                
                if (user == null)
                {
                    return BadRequest("Bad login or password");
                }

                return Ok(user);
            }
        }
    }
}
