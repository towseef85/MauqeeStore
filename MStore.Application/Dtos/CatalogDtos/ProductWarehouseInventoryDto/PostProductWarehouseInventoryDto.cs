namespace MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto
{
    public class PostProductWarehouseInventoryDto
    {
        public Guid Id { get; set; }
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
        public Decimal StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the reserved quantity (ordered but not shipped yet)
        /// </summary>
        public Decimal ReservedQuantity { get; set; }
    }
}