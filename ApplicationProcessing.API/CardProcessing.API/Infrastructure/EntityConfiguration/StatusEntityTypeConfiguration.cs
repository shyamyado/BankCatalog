using ApplicationProcessing.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationProcessing.API.Infrastructure.Entityconfiguration
{
    public class StatusEntityTypeConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");
            builder.HasKey(x => x.Id).IsClustered();
            builder.Property(x => x.StatusName).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
        }
    }
}
