using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Storage
    {
        public Storage()
        {
            Shops = new HashSet<Shop>();
            StorageProducts = new HashSet<StorageProduct>();
        }

        public int StorageId { get; set; }
        public double? Area { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<StorageProduct> StorageProducts { get; set; }
    }
}
