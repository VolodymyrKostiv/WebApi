using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/storages")]
    public class StorageController : ControllerBase
    {
        private readonly ILogger<StorageController> _logger;
        private readonly IMapper _mapper;
        private readonly CourseWork_PlumbingStoreContext _context;

        public StorageController(ILogger<StorageController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _context = new CourseWork_PlumbingStoreContext();
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetProductsOnStorageByEmployee(int employeeID)
        {
            if (employeeID < 1)
            {
                return BadRequest("Invalid employee ID");
            }

            try
            {
                string storedProcedure = "EXEC SelectProductsFromStore @EmployeeID = " + employeeID;
                var res = _context.ShopStorageProducts.FromSqlRaw(storedProcedure).ToList();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteStorage(int id)
        //{

        //}

        [HttpPost]
        public async Task<IActionResult> CreateStorage(StorageDTO storageDTO)
        {
            var res = new Storage()
            {
                Area = storageDTO.Area,
            };

            _context.Storages.Add(res);
            _context.SaveChanges();

            return Ok(storageDTO);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStorage(StorageDTO storageDTO)
        {
            var target = _context.Storages.Find(storageDTO.StorageId);
            if (target == null)
                return BadRequest("No storage with such ID");

            target.Area = storageDTO.Area;

            _context.Storages.Update(target);
            _context.SaveChanges();

            return Ok(storageDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStorages()
        {
            var res = _context.Storages.ToArray();
            var storages = new List<StorageDTO>();
            foreach (var shop in res)
            {
                var temp = new StorageDTO() { Area = shop.Area, StorageId = shop.StorageId };
                storages.Add(temp);
            }

            return Ok(storages);
        }

    }
}