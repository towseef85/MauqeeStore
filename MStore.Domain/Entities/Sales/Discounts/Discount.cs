using System;
namespace MStore.Domain.Entities.Sales.Discounts
{
	public class Discount :BaseEntity
	{
		public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public Guid DiscountTypeId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool RequiresCouponCode { get; set; }
        public string CouponCode { get; set; }
        //public bool IsCumulative { get; set; }
        //public int DiscountLimitationId { get; set; }
        //public int LimitationTimes { get; set; }
        public int? MaximumDiscountedQuantity { get; set; }
        public virtual DiscountType DiscountType { get; set; }
    }
}

