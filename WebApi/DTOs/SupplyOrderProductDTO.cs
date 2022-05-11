using Microsoft.EntityFrameworkCore;

namespace WebApi.DTOs
{
    [Keyless]
    public class SupplyOrderProductDTO
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public int SupplyOrderId { get; set; }
    }
}
