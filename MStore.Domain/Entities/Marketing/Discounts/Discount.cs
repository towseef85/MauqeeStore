using System;
namespace MStore.Domain.Entities.Marketing.Discounts
{
	public class Discount :BaseEntity
	{
		public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public Guid DiscountTypeId { get; set; }
        public bool IsPercent { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool RequiresCouponCode { get; set; }
        public string CouponCode { get; set; }
        public int LNTimesPerCustomer { get; set; }
        public int LNTimes { get; set; }
        public int? MaximumDiscountedQuantity { get; set; }
        public bool IsCODFree { get; set; }
        public bool IsShippingFree { get; set; }
        public virtual DiscountType DiscountType { get; set; }
    }
}

