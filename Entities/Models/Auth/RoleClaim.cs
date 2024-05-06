using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Auth
{
    public class RoleClaim : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int ClaimId { get; set; }
        public Claim Claim { get; set; }

    }
}
