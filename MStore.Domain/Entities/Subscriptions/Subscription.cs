using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Subscriptions
{
    public class Subscription :BaseEntity
    {
        public Guid PlanId { get; set; }

        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Plans Plans { get; set; }
    }
}
