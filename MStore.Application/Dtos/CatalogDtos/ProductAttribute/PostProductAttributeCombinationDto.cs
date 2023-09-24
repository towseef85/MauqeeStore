using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.CatalogDtos.ProductAttribute
{
    public class PostProductAttributeCombinationDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SubscriptionId { get; set; }
        public Guid ProductId { get; set; }
        public Guid AttributeValueId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string? Sku { get; set; }
        public string? Gtin { get; set; }
        public string PictureId { get; set; }
        public int StockQuantity { get; set; }
        public bool AllowOutOfStockOrders { get; set; } = false;
        public int? NotifyAdminForQuantityBelow { get; set; }
    }
}
