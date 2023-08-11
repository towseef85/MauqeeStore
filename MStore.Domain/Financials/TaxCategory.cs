using MStore.Domain.Entities;
using MStore.Domain.Entities.Catalog.Products;

namespace MStore.Domain.Financials
{
    public class TaxCategory : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string CategoryName { get; set; }
        public float Value { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
