using Entities.DTOs;
using Entities.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.ManagerDal;

public class ManagerRepository : GenericRepository<Manager> , IManagerRepository
{
    private readonly AppDbContext _context;      
    public ManagerRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Response<Manager>> GetByUsernameAsync(string username, string passwordHash)
    {
        try
        {
            var manager = await _context.Managers.FirstOrDefaultAsync(m => m.UserName == username && m.PasswordHash == passwordHash);
            if (manager == null)
                return new Response<Manager>(false, "Entity not found.", null);

            return new Response<Manager>(true, "", manager);
        }
        catch (Exception ex)
        {
            return new Response<Manager>(false, $"Error getting entity: {ex.Message}", null);
        }

    

    }
}
