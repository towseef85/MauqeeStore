using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.BrandDto;

namespace MStore.Application.CatalogBL.BrandBL
{
    public class BrandValidation : AbstractValidator<PostBrandDto>
    {
        public BrandValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}
