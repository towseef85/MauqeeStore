namespace MStore.Application.Dtos.CatalogDtos.Category
{
    public class GetCategoriesDto
    {
        public Guid Id { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public string? ImageData { get; set; }
        public bool ShowOnHomepage { get; set; } = false;
        public bool Published { get; set; } = true;
        public int? DisplayOrder { get; set; }
    }
}
