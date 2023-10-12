using FluentValidation;
using MStore.Application.Dtos.ShippingDto.DeliveryDateDto;
namespace MStore.Application.ShippingBL.DeliveryDateBL
{
    public class DeliveryDateValidation : AbstractValidator<PostDeliveryDateDto>
    {
        public DeliveryDateValidation()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
