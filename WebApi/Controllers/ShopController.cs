using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/shops")]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IMapper _mapper;
        private readonly CourseWork_PlumbingStoreContext _context;

        public ShopController(ILogger<ShopController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShop(ShopDTO shop)
        {
            var res = new Shop()
            {
                Address = shop.Address,
                StorageId = shop.StorageId,
            };

            _context.Shops.Add(res);
            _context.SaveChanges();

            return Ok(shop);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShop(ShopDTO shop)
        {
            var target = _context.Shops.Find(shop.ShopId);
            if (target == null)
                return BadRequest("No shop with such ID");

            target.StorageId = shop.StorageId;
            target.Address = shop.Address;

            _context.Shops.Update(target);
            _context.SaveChanges();

            return Ok(shop);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShops()
        {
            var res = _context.Shops.Include(x => x.Storage).ToArray();
            var shops = new List<ShopDTO>();
            foreach (var shop in res)
            {
                var temp = new ShopDTO() { ShopId = shop.ShopId, Address = shop.Address, StorageId = shop.StorageId };
                shops.Add(temp);
            }

            return Ok(shops);
        }
    }
}