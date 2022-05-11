using Microsoft.EntityFrameworkCore;

namespace WebApi.DTOs
{
    [Keyless]
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
