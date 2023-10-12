using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.SalesDto.OrderItemDto
{
    public class GetOrderItemDto
    {
        //public Guid SubscriptionId { get; set; }
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPriceInclTax { get; set; }
        public decimal UnitPriceExclTax { get; set; }
        public decimal PriceInclTax { get; set; }
        public decimal PriceExclTax { get; set; }
        public decimal DiscountAmountInclTax { get; set; }
        public decimal DiscountAmountExclTax { get; set; }
        public decimal OriginalProductCost { get; set; }
        public string AttributeDescription { get; set; }
        //public string AttributesXml { get; set; }
        public int DownloadCount { get; set; }
        public bool IsDownloadActivated { get; set; }
        public int? LicenseDownloadId { get; set; }
        public decimal? ItemWeight { get; set; }
        //public DateTime? RentalStartDateUtc { get; set; }
        //public DateTime? RentalEndDateUtc { get; set; }
    }
}