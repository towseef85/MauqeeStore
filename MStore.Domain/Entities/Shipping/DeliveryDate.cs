using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Shipping
{
    public class DeliveryDate : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public int DisplayOrder { get; set; }
    }
}