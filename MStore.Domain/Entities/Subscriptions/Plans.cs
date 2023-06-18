    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Subscriptions
{
    public class Plans : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }

    }
}
