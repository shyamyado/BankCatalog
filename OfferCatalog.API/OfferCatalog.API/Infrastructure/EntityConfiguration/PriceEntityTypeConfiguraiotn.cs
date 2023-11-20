using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.EntityConfiguration
{
    public class PriceEntityTypeConfiguraiotn : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Price");
            builder.HasKey(x => x.PriceId).IsClustered();
            builder.Property(x => x.DefaultCreditLimit).IsRequired();
            builder.Property(x => x.AnnualFees);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.CreatedAt);
        }
    }
}
