using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/supplyOrders")]
    public class SupplyOrderController : ControllerBase
    {
        private readonly ILogger<SupplyOrderController> _logger;
        private readonly IMapper _mapper;
        private readonly CourseWork_PlumbingStoreContext _context;

        public SupplyOrderController(ILogger<SupplyOrderController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplyOrder(SupplyOrderDTO supplyOrderDTO)
        {
            var supplyOrder = _mapper.Map<SupplyOrderDTO, SupplyOrder>(supplyOrderDTO);

            try
            {
                var reviewStateIndex = _context.SupplyOrderStates.Where(x => x.Title == "Review").First();
                supplyOrder.SupplyOrderStateId = reviewStateIndex.SupplyOrderStateId;

                var employee = supplyOrder.Employee;
                supplyOrder.Employee = null;

                supplyOrder.SupplyOrderState = null;
                
                var supplier = supplyOrder.Supplier;
                supplyOrder.Supplier = null;

                _context.SupplyOrders.Add(supplyOrder);

                //_context.Entry(supplyOrder.SupplyOrderState).State = EntityState.Unchanged;
                //_context.Entry(supplyOrder.Employee).State = EntityState.Unchanged;
                //_context.Entry(supplyOrder.Supplier).State = EntityState.Unchanged;

                //_context.SaveChanges();
                //foreach (var supplyOrderProd in supplyOrder.SupplyOrderProducts)
                //{
                //    supplyOrderProd.SupplyOrderId = supplyOrder.SupplyOrderId;

                //    _context.SupplyOrderProducts.Add(supplyOrderProd);
                //}
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(supplyOrder);
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplyOrdersByEmployee(int employeeID)
        {
            if (employeeID < 1)
            {
                return BadRequest("Invalid employee ID");
            }

            try
            {
                var res = _context.SupplyOrders
                    .Where(x => x.EmployeeId == employeeID)
                    .Include(x => x.Supplier)
                    .Include(x => x.SupplyOrderProducts)
                        .ThenInclude(y => y.Product)
                            .ThenInclude(y => y.UnitOfMeasurement)
                    .Include(x => x.SupplyOrderState)
                    .ToList();          

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}