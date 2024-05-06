using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Entities.Models.Auth;

namespace Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
        
    public DbSet<Claim> Claims { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<ManagerRole> ManagerRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategori> ProductCategoris { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
   


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //hepsini buluyor ve uyguluyor
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

   


}