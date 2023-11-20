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
            builder.HasKey(x => x.ItemId).IsClustered();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.JoiningFees);
            builder.Property(x => x.Category);
            builder.Property(x => x.SubCategory);
            builder.Property(x => x.Type);
            builder.Property(x => x.DepartmentId);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.IsPhysical);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
        }
    }
}
