using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeDto;

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
