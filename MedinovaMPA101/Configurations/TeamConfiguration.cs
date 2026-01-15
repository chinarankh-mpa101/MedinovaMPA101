using MedinovaMPA101.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedinovaMPA101.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Position).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1024);
            builder.HasMany(x => x.Blogs).WithOne(x => x.Team).HasForeignKey(x => x.TeamId).HasPrincipalKey(x => x.Id);
        }
    }
}
