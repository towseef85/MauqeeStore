using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStore.Domain.Entities.Catalog.Common;

namespace MStore.Persistence.EntityConfig
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Subscriptions)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.SubscriptionId);
        }
    }
}
