using Entities.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class ManagerConfiguration
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Managers"); // Tablo adını belirtin
            builder.HasKey(m => m.Id); // Anahtar alanını belirtin
            builder.Property(m => m.UserName).IsRequired();
            builder.Property(m => m.PasswordHash).IsRequired();
            builder.Property(m => m.Email).IsRequired();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.LastName).IsRequired();
            builder.Property(m => m.PhoneNumber).IsRequired();

            // Diğer özellikler ve ilişkiler buraya eklenebilir

            // Manager ve ManagerRole arasındaki ilişkiyi belirtin
            builder.HasMany(m => m.ManagerRoles)
                .WithOne(mr => mr.Manager)
                .HasForeignKey(mr => mr.ManagerId);
        }
    }

}
