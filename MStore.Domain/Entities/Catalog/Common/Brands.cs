using MStore.Domain.Entities.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Catalog.Common
{
    public class Brand : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; } = true;
        public string? ImageData { get; set; }
        public bool ShowOnHomepage { get; set; } = false;
        public int? DisplayOrder { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
