namespace WebApi.DTOs
{
    public class SupplyOrderStateChangedDTO
    {
        public int SupplyOrderId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public int SupplyOrderStateId { get; set; }
    }
}
