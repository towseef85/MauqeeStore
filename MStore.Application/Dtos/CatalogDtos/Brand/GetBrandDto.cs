namespace MStore.Application.Dtos.CatalogDtos.Brand
{
    public class GetBrandDto
    {
        public Guid Id { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; } = true;
        public string? ImageId { get; set; }
        public bool ShowOnHomepage { get; set; } = false;
        public int? DisplayOrder { get; set; }
    }
}
