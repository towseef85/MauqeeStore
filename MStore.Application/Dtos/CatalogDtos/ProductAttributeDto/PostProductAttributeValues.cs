using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.CatalogDtos.ProductAttributeDto
{
    public class PostProductAttributeValues
    {
        public Guid Id { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }

    }
}
