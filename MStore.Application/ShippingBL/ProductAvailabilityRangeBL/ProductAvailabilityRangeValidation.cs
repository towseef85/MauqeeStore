using FluentValidation;
using MStore.Application.Dtos.ShippingDto.ProductAvailabilityRangeDto;
namespace MStore.Application.ShippingBL.ProductAvailabilityRangeBL
{
    public class ProductAvailabilityRangeValidation : AbstractValidator<PostProductAvailabilityRangeDto>
    {
        public ProductAvailabilityRangeValidation()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
