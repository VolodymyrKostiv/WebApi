namespace WebApi.DTOs
{
    public class PurchaseOrderDTO
    {
        public PurchaseOrderDTO()
        {
            PurchaseOrderProducts = new HashSet<PurchaseOrderProductDTO>();
        }

        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public int EmployeeId { get; set; }

        public IEnumerable<PurchaseOrderProductDTO> PurchaseOrderProducts { get; set; }
    }
}
