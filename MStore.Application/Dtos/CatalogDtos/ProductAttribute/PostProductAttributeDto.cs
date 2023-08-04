namespace MStore.Application.Dtos.CatalogDtos.ProductAttribute
{
    public class PostProductAttributeDto
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string Value { get; set; }
        public string PictureId { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
