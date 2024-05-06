using Entities.DTOs;
using Entities.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.ManagerService
{
    public interface IManagerService
    {
        Task<Response<Manager>> GetByUsernameAsync(string username, string passwordHash);
    }
}
