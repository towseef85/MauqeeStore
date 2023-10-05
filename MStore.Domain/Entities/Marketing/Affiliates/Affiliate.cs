
namespace MStore.Domain.Entities.Marketing.Affiliates
{
    
namespace Domain.Affiliates

{
    public partial class Affiliate : BaseEntity
    {   
        public Guid SubscriptionId { get; set; }
        public string AdminComment { get; set; }
        public string FriendlyUrlName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        //public virtual Address Address { get; set; }
    }
}

}