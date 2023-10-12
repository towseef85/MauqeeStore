using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Financials;
using MStore.Domain.Financials;

namespace MStore.Domain.Entities.Catalog.Products
{
    public class Product : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string? Description { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public Guid? ParentProductId { get; set; }
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
        public virtual Category Category { get; set; }
        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public Guid? ProductTagId { get; set; }
        public Guid TaxCategoryId { get; set; }
        public Guid DeliveryDateId { get; set; }
        public Guid ProductAvailabilityRangeId { get; set; }
        public virtual TaxCategory TaxCategory { get; set; }
        public ICollection<ProductTags>? ProductTags { get; set; }
        public ICollection<ProductAttributeCombination> ProductAttributeCombinations { get; set; }
    }
}
