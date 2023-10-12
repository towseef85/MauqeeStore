namespace MStore.Application.Dtos.CatalogDtos.CategoryDto
{
    public class GetCategoriesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
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
