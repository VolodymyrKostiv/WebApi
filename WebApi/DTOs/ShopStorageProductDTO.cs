using Microsoft.EntityFrameworkCore;

namespace WebApi.DTOs
{
    [Keyless]
    public class ShopStorageProductDTO
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; } 
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }
}
