namespace MStore.Application.Dtos.FinanceDto.FaqDto
{
    public class PostFaqDto
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string Question { get; set; }
        public string OtherTitle { get; set; }
        public string Answer { get; set; }
        public string Published { get; set; }
        public int DisplayOrder { get; set; }
    }
}