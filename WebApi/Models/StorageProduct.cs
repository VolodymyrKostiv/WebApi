using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class StorageProduct
    {
        public double Quantity { get; set; }
        public int StorageId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Storage Storage { get; set; } = null!;
    }
}
