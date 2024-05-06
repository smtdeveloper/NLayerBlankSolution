using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedUser { get; set; }
        public int? UpdatedUser { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
