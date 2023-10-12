namespace MStore.Application.Dtos.CatalogDtos.ProductAttributeDto
{
    public class PostProductAttributeDto
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public ICollection<PostProductAttributeValues> AttributeValues { get; set; }
    }
}
