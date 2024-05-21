using Entities.DTOs;
using Entities.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;
using Repository.Repositories.ManagerDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.ManagerService;

public class ManagerService : GenericService<Manager>, IManagerService
{
    private readonly IManagerRepository _managerRepository;

    public ManagerService(IManagerRepository managerRepository) : base(managerRepository)
    {
        _managerRepository = managerRepository;
    }

    async Task<Response<Manager>> IManagerService.GetByUserAsync(string username, string password)
    {

        var manager =  await _managerRepository.GetByUsernameAsync(username, password);
        return manager;

    }
}
