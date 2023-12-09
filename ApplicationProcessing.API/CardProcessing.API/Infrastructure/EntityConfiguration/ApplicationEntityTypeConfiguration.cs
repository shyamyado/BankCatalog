using ApplicationProcessing.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationProcessing.API.Infrastructure.Entityconfiguration
{
    public class ApplicationEntityTypeConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Application");
            builder.HasKey(x => x.Id).IsClustered();
            builder.Property(x => x.CardId).IsRequired();
            builder.Property(x => x.CustomerId);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

        }
    }
}
