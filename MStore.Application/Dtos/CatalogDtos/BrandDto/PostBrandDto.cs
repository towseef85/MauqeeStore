namespace MStore.Application.Dtos.CatalogDtos.BrandDto
{
    public class PostBrandDto
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; } = true;
        public string ImageData { get; set; }
        public bool ShowOnHomepage { get; set; } = false;
        public int? DisplayOrder { get; set; }
    }
}
