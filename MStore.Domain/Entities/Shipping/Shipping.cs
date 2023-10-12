using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Financials
{
    public class Shipping : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public float Value { get; set; }
        public bool IsActive { get; set; }
    }
}
