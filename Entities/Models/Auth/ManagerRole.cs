using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Auth
{
    public class ManagerRole
    {
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
