using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Catalog.Products
{
    public class ProductTags : BaseEntity
    {
        public string EngName { get; set; }
        public string OtherName { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
