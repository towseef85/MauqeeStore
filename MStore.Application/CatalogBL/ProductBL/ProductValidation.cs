using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CatalogBL.ProductBL
{
    public class ProductValidation : AbstractValidator<PostProductDto>
    {
        public ProductValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.OtherName).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
        }
    }
}
