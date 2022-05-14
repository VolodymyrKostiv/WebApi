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

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(supplyOrder);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSupplyOrder(int supplyOrderId)
        {
            var order = _context.SupplyOrders.Find(supplyOrderId);
            if (order == null)
                return NotFound();

            var orderProduct = _context.SupplyOrderProducts.Where(x => x.SupplyOrderId == order.SupplyOrderId).ToList();

            foreach (var product in orderProduct)
            {
                _context.SupplyOrderProducts.Remove(product);
            }

            _context.SupplyOrders.Remove(order);
            
            _context.SaveChanges();

            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> PutSupplyOrder(SupplyOrderStateChangedDTO supplyOrder)
        {
            var order = await _context.SupplyOrders.Where(x => x.SupplyOrderId == supplyOrder.SupplyOrderId).FirstOrDefaultAsync();
            order.SupplyOrderStateId = supplyOrder.SupplyOrderStateId;
            _context.SupplyOrders.Update(order);
            _context.SaveChanges();
            return Ok();
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