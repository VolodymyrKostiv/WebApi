using WebApi.Models;

namespace WebApi.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? BrandId { get; set; }
        public int? UnitOfMeasurementId { get; set; }
        public int? SubcategoryId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Subcategory? Subcategory { get; set; }
        public virtual UnitOfMeasurement? UnitOfMeasurement { get; set; }
    }
}
