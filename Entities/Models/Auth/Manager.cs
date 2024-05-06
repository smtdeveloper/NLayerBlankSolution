using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Auth
{
    public class Manager : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        // Diğer yönetici bilgileri (isim, soyisim, telefon numarası vb.) buraya eklenebilir
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        // Yöneticinin rolleri
        public virtual ICollection<ManagerRole> ManagerRoles { get; set; }

    }
}
