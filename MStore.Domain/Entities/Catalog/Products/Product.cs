using MStore.Domain.Entities.Catalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Catalog.Products
{
    public class Product : BaseEntity
    {
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string? Description { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public Guid? ParentProductId { get; set; }
        public Guid? ImageId { get; set; }
        public bool ShowOnHomepage { get; set; } = false;
        public bool Published { get; set; } = true;
        public int? DisplayOrder { get; set; }
        public string? Sku { get; set; }
     
        public string? Gtin { get; set; }
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public bool AllowCustomerReviews { get; set; } = true;
        public bool IsDownload { get; set; } = false;
        public int? MaxNumberOfDownloads { get; set; }

        public bool IsRental { get; set; } = false;
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid BrandId { get; set; }
        public virtual Brands Brands { get; set; }
        public ICollection<ProductTags>? ProductTags { get; set; }
    }
}
