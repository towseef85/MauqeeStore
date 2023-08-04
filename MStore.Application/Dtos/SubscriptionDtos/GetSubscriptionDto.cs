namespace MStore.Application.Dtos.SubscriptionDtos
{
    public class GetSubscriptionDto
    {
        public Guid Id { get; set; }
        public Guid PlanId { get; set; }
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
