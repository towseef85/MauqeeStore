namespace MStore.Domain.Entities.Financials
{
    public class TermAndCondition: BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string Published { get; set; }
        public int DisplayOrder { get; set; }

    }
}