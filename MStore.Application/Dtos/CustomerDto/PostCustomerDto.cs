using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.CustomerDto
{
    public class PostCustomerDto

    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string Email { get; set; }
        public string AdminComment { get; set; }
        public bool IsTaxExempt { get; set; }
        public int AffiliateId { get; set; }
        public bool HasShoppingCartItems { get; set; }
        public bool Active { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime LastActivityDateUtc { get; set; }
        public int RegisteredInStoreId { get; set; }
        
    }
}
