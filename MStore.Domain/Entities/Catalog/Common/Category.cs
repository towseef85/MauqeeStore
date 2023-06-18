using MStore.Domain.Entities.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Catalog.Common
{
    public class Category : BaseEntity 
    {
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public string? ImageId { get; set; }
        public bool ShowOnHomepage { get; set; } = false;
        public bool Published { get; set; } = true;
        public int? DisplayOrder { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
