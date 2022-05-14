using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/purchaseOrders")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly ILogger<PurchaseOrderController> _logger;
        private readonly CourseWork_PlumbingStoreContext _context;
        private readonly IMapper _mapper;

        public PurchaseOrderController(ILogger<PurchaseOrderController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrders(int employeeID)
        {
            if (employeeID < 1)
            {
                return BadRequest("Invalid employee ID");
            }

            try
            {
                var orders = _context.PurchaseOrders
                    .Where(order => order.EmployeeId == employeeID)
                    .Select(x => x)
                    .Include(x => x.PurchaseOrderProducts)
                        .ThenInclude(x => x.Product)
                    .ToList();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePurchaseOrder(int orderID)
        {
            var order = _context.PurchaseOrders.Find(orderID);
            if (order == null)
                return NotFound();

            var orderProducts = _context.PurchaseOrderProducts.Where(x => x.PurchaseOrderId == order.PurchaseOrderId).ToList();

            foreach (var product in orderProducts)
            {
                _context.PurchaseOrderProducts.Remove(product);
            }

            _context.PurchaseOrders.Remove(order);

            _context.SaveChanges();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder(PurchaseOrderDTO purchaseOrderDTO)
        {
            using var transaction = _context.Database.BeginTransaction();
            var purchaseOrder = _mapper.Map<PurchaseOrderDTO, PurchaseOrder>(purchaseOrderDTO);

            try
            {
                _context.PurchaseOrders.Add(purchaseOrder);
                _context.SaveChanges();

                foreach (var purchProdDTO in purchaseOrderDTO.PurchaseOrderProducts)
                {
                    var purchProd = _mapper.Map<PurchaseOrderProductDTO, PurchaseOrderProduct>(purchProdDTO);
                    purchProd.PurchaseOrderId = purchaseOrder.PurchaseOrderId;

                    var employee = _context.Employees
                        .Where(x => x.EmployeeId == purchaseOrder.EmployeeId)
                        .Include(x => x.Shop)
                            .ThenInclude(x => x.Storage)
                        .First();

                    var stockItem = _context.StorageProducts
                        .FirstOrDefault(x => x.ProductId == purchProd.ProductId
                                             && x.StorageId == employee.Shop.StorageId);

                    if (stockItem == null)
                    {
                        throw new Exception("No item with such ID");
                    }

                    if (stockItem.Quantity < purchProd.Quantity)
                    {
                        throw new Exception("Not enough products on the storage");
                    }
                    _context.Database.ExecuteSqlRaw($"UPDATE StorageProduct SET Quantity = {stockItem.Quantity - purchProd.Quantity} " +
                        $"WHERE StorageID = {stockItem.StorageId} AND ProductID = {stockItem.ProductId}");

                    //_context.PurchaseOrderProducts.Add(purchProd);
                }
                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(purchaseOrder);
        }
    }
}