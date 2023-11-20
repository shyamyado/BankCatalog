using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.EntityConfiguration
{
    public class BenefitEntityTypeConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.ToTable("Benefits");
            builder.HasKey(x => x.BenefitId).IsClustered();
            builder.Property(x => x.BenefitName).IsRequired();
            builder.Property(x => x.BenefitAmount);

        }
    }
}
