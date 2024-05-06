using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ProductCategori : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoriId { get; set; }
        public Category Categori { get; set; }

    }
}
