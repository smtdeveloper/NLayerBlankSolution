using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string CoverPhotoUrl { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
