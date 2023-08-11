using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.CatalogDtos.TaxCategory
{
    public class GetTaxCategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public float Value { get; set; }
    }
}
