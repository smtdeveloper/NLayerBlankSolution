using Entities.DTOs;
using Entities.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.ManagerDal
{
    public interface IManagerRepository
    {
        Task<Response<Manager>> GetByUsernameAsync(string username, string passwordHash);
    }
}
