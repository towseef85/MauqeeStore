namespace MStore.Domain.Entities.Financials
{
    public class Faq : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string Question { get; set; }
        public string OtherTitle { get; set; }
        public string Answer { get; set; }
        public string Published { get; set; }
        public int DisplayOrder { get; set; }
    }
}