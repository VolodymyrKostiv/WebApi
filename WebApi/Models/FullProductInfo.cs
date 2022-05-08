using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class FullProductInfo
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public string? Subcategory { get; set; }
        public string Category { get; set; } = null!;
    }
}
