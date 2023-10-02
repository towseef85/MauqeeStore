using System;
namespace MStore.Domain.Entities.Sales.Discounts
{
	public class DiscountType:BaseEntity
	{
		public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string Type { get; set; }
        public ICollection<Discount>Discounts { get; set; }
    }
}

