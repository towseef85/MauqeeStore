using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.FinanceDto.TaxCategoryDto
{
    public class PostTaxCategoryDto
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public float Value { get; set; }
    }
}
