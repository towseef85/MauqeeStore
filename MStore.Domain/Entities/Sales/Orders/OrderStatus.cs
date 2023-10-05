using System;
namespace MStore.Domain.Entities.Sales.Orders
{
  public partial class OrderStatus : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public bool IsActive { get; set; }
        
    }
}
    



