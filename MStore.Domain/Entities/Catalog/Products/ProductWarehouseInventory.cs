namespace MStore.Domain.Entities.Catalog.Products
{
    public class ProductWarehouseInventory : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
         /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the warehouse identifier
        /// </summary>
        public Guid WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the stock quantity
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the reserved quantity (ordered but not shipped yet)
        /// </summary>
        public int ReservedQuantity { get; set; }
    }
}
