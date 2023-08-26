using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Financials
{
    public class Currency : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string Symbol { get; set; }
        public bool IsActive { get; set; }
    }
}
