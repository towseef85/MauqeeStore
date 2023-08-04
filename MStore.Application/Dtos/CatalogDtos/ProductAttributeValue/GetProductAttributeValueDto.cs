using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.CatalogDtos.ProductAttributeValue
{
    public class GetProductAttributeValueDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string PictureId { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
