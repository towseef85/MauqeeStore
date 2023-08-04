using MStore.Application.Dtos.CatalogDtos.ProductAttributeValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.CatalogDtos.ProductAttribute
{
    public class GetProductAttributeDto
    {
        public Guid Id { get; set; }
        public string EngName { get; set; }
        public string? OtherName { get; set; }
        public List<GetProductAttributeValueDto> ProductAttributeValue { get; set; }
    }

    
}
