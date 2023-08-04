using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStore.Domain.Entities.Identities;
using MStore.Domain.Entities.Subscriptions;

namespace MStore.Persistence.EntityConfig
{
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Plans)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.PlanId);
            builder.HasOne(x=>x.Users)
                   .WithOne(x => x.Subscriptions)
                   .HasForeignKey<AppUsers>(x => x.SubscriptionId);
        }
    }
}
