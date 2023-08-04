namespace MStore.Domain.Entities.Catalog.Products
{
    public class ProductAttribute : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
