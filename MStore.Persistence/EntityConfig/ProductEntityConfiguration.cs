using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStore.Domain.Entities.Catalog.Products;

namespace MStore.Persistence.EntityConfig
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Brand)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.BrandId);
        }
    }
}
