namespace MStore.Domain.Entities.Catalog.Products
{
    public class ProductAttributeCombination : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string? Sku { get; set; }
        public string? Gtin { get; set; }
        public string PictureId { get; set; }
        public int StockQuantity { get; set; }
        public bool AllowOutOfStockOrders { get; set; }= false;
        public int? NotifyAdminForQuantityBelow { get; set; }
        public virtual Product Products { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }

    }
}
