using MStore.Application.Dtos.CatalogDtos.ProductAttribute;

namespace MStore.Application.Dtos.CatalogDtos.Product
{
    public class GetProductDto
    {
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string? Description { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public Guid? ParentProductId { get; set; }
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
        public Guid UserId { get; set; }
        public Guid? ProductTagId { get; set; }
        public Guid? ProductAttributeCombinationId { get; set; }
        public ICollection<GetProductAttributeCombinationDto> AttributeCombination { get; set; }
    }
}
