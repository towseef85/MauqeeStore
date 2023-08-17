namespace MStore.Domain.Entities.Catalog.Products
{
    public class ProductAttributeValue : BaseEntity
    {
        public Guid ProductAttributeId { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
