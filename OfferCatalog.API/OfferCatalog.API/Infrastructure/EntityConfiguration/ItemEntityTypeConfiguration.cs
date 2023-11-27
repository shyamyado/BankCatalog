using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.EntityConfiguration
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(x => x.Id).IsClustered();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.ShortDescription);
            builder.Property(x => x.JoiningFees);
            builder.Property(x => x.AnnualFees);
            builder.HasOne(ci => ci.Category)
              .WithMany()
              .HasForeignKey(ci => ci.CategoryId);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.IsPhysical);
            builder.Property(x => x.Image);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
        }
    }
}
