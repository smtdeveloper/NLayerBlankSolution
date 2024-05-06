using Entities.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ManagerRoleConfiguration : IEntityTypeConfiguration<ManagerRole>
    {
        public void Configure(EntityTypeBuilder<ManagerRole> builder)
        {
            builder.ToTable("ManagerRoles");
            builder.HasKey(mr => new { mr.ManagerId, mr.RoleId });

            // Diğer özellikler buraya eklenebilir

            // Manager ve Role arasındaki ilişkiyi belirtin
            builder.HasOne(mr => mr.Manager)
                .WithMany(m => m.ManagerRoles)
                .HasForeignKey(mr => mr.ManagerId);

            builder.HasOne(mr => mr.Role)
                .WithMany(r => r.ManagerRoles)
                .HasForeignKey(mr => mr.RoleId);
        }
    }

}
