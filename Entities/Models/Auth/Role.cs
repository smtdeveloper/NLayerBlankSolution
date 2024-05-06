using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Auth
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        // Bir rolün sahip olduğu yetkiler
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
        // Yöneticinin rolleri
        public virtual ICollection<ManagerRole> ManagerRoles { get; set; }
    }
}

