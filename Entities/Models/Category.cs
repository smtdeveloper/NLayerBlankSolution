using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string CoverPhotoUrl { get; set; }
        public virtual ICollection<ProductCategori> ProductCategoris { get; set; }
    }
}
