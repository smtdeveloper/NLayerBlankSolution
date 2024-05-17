using Entities.DTOs;
using Entities.Models.Auth;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.ManagerService
{
    public interface IManagerService : IGenericService<Manager>
    {
        Task<Response<Manager>> GetByUsernameAsync(string username, string passwordHash);
    }
}
