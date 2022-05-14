using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        private readonly CourseWork_PlumbingStoreContext _context;

        public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper)  
        {
            _logger = logger;
            _mapper = mapper;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var userType = _context.EmployeeTypes.Where(x => x.Title == employeeDTO.EmployeeType).FirstOrDefault();
            if (userType == null)
                return BadRequest("No such type");

            var existing = _context.Employees.Where(x => x.LoginDatum.LoginName == employeeDTO.Login).FirstOrDefault();
            if (existing != null)
            {
                return BadRequest("User with such login already exists");
            }

            Employee employee = new Employee()
            {
                EmployeeTypeId = userType.EmployeeTypeId,
                ShopId = employeeDTO.ShopID,
            };

            _context.Employees.Add(employee);

            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            LoginDatum loginData = new LoginDatum() 
            { 
                EmployeeId = employee.EmployeeId, 
                LoginName = employeeDTO.Login, 
                Password = employeeDTO.Password };
            PersonalDatum persData = new PersonalDatum() 
            {
                EmployeeId = employee.EmployeeId, 
                FirstName = employeeDTO.FirstName, 
                LastName = employeeDTO.LastName,
                PhoneNumber = employeeDTO.PhoneNumber,
            };

            _context.PersonalData.Add(persData);
            _context.LoginData.Add(loginData);

            _context.SaveChanges();

            return Ok(employeeDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _context.Employees.Find(employeeDTO.EmployeeId);
            if (employee == null)
                return BadRequest("Employee wasn't found");

            var userType = _context.EmployeeTypes
                .Where(x => x.Title == employeeDTO.EmployeeType)
                .FirstOrDefault();
            if (userType == null)
                return BadRequest("No such type");

            var login = _context.LoginData.Find(employeeDTO.EmployeeId);
            var personal = _context.PersonalData.Find(employeeDTO.EmployeeId);

            login.LoginName = employeeDTO.Login;
            login.Password = employeeDTO.Password;
            personal.PhoneNumber = employeeDTO.PhoneNumber;
            personal.FirstName = employeeDTO.FirstName;
            personal.LastName = employeeDTO.LastName;
            personal.PhoneNumber = employeeDTO.PhoneNumber;
            employee.ShopId = employeeDTO.ShopID;
            employee.EmployeeTypeId = userType.EmployeeTypeId;

            _context.Employees.Update(employee);
            _context.PersonalData.Update(personal);
            _context.LoginData.Update(login);

            _context.SaveChanges();

            return Ok(employeeDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = _context.Employees
                .Include(x => x.PersonalDatum)
                .Include(x => x.LoginDatum)
                .Include(x => x.EmployeeType)
                .ToArray();

            var res = new List<EmployeeDTO>();

            foreach (var employee in employees)
            {
                var temp = new EmployeeDTO()
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.PersonalDatum.FirstName,
                    LastName = employee.PersonalDatum.LastName,
                    PhoneNumber = employee.PersonalDatum.PhoneNumber,
                    Password = employee.LoginDatum.Password,
                    Login = employee.LoginDatum.LoginName,
                    EmployeeType = employee.EmployeeType.Title,
                    ShopID = employee.ShopId,
                };
                res.Add(temp);
            }

            return Ok(res);
        }
    }
}