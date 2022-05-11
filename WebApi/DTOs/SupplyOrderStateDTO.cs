using Microsoft.EntityFrameworkCore;

namespace WebApi.DTOs
{
    [Keyless]
    public class SupplyOrderStateDTO
    {
        public int SupplyOrderStateId { get; set; }
        public string Title { get; set; }
    }
}
