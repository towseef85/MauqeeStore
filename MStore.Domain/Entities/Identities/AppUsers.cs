using Microsoft.AspNetCore.Identity;
using MStore.Domain.Entities.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Identities
{
    public class AppUsers : IdentityUser
    {
        public string EngName { get; set; }
        public string ArbName { get; set; }

        public string UserType { get; set; }
        public string Remarks { get; set; }
        public Guid SubscriptionId { get; set; }
        public Subscription Subscriptions { get; set; }


    }
}
