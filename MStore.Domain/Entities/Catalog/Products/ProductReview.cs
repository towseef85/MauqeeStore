using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Catalog.Products
{
    public class ProductReview :BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public string ReviewDesc { get; set; }
        public bool Published { get; set; }
        
    }
}