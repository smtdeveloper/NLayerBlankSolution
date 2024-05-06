using Entities.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ClaimConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable("Claims");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Type).IsRequired();
            builder.Property(c => c.Value).IsRequired();

            // Diğer özellikler ve ilişkiler buraya eklenebilir
        }
    }

}
