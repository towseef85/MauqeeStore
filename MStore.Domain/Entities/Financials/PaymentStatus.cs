using System;
namespace MStore.Domain.Entities.Financials
{
  public partial class PaymentStatus : BaseEntity
    {
      
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public bool IsActive { get; set; }
        
    }
}
    



