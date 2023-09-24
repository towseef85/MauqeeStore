using MStore.Application.Dtos.CatalogDtos.ProductAttribute;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeValue;

namespace MStore.Application.Dtos.CatalogDtos.Product
{
    public class PostProductDto
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string? Description { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public Guid? ParentProductId { get; set; }
        public Guid TaxCategoryId { get; set; }
        public Guid? PictureId { get; set; }
        public bool ShowOnHomepage { get; set; } = false;
        public bool Published { get; set; } = true;
        public int? DisplayOrder { get; set; }
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public bool AllowCustomerReviews { get; set; } = true;
        public bool IsDownload { get; set; } = false;
        public int? MaxNumberOfDownloads { get; set; }
        public bool IsRental { get; set; } = false;
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Guid UserId { get; set; }
        public Guid? ProductTagId { get; set; }
        public ICollection<PostProductAttributeCombinationDto> ProductAttributeCombinations { get; set; }
    }
}
