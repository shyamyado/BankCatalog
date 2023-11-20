using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.EntityConfiguration
{
    public class RewardPointsEnitityTypeConfiguration : IEntityTypeConfiguration<RewardPoints>
    {
        public void Configure(EntityTypeBuilder<RewardPoints> builder)
        {
            builder.ToTable("RewardPoints");
            builder.HasKey(x => x.PointId).IsClustered();
            builder.Property(x => x.Points);
            builder.Property(x => x.AddedDate);
            builder.Property(x => x.ExpiredDate);

        }
    }
}
