using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.ProductAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CatalogBL.ProductAttributeBL
{
    public class ProductAttributeValidation : AbstractValidator<PostProductAttributeDto>
    {
        public ProductAttributeValidation()
        {
            RuleFor(x => x.EngName).NotNull().NotEmpty();
            RuleFor(x => x.SubscriptionId).NotNull().NotEmpty();
            RuleFor(x => x.AttributeValues).NotNull().NotEmpty();
        }
    }
}
