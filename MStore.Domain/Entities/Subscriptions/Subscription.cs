using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Identities;

namespace MStore.Domain.Entities.Subscriptions
{
    public class Subscription :BaseEntity
    {
        public Guid PlanId { get; set; }
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public AppUsers Users  { get; set; }
        public bool IsActive { get; set; }
        public virtual Plans Plans { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
