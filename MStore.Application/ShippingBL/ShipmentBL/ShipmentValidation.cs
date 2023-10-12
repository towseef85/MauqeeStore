using FluentValidation;
using MStore.Application.Dtos.ShippingDto.ShipmentDto;
namespace MStore.Application.ShippingBL.ShipmentBL
{
    public class ShipmentValidation : AbstractValidator<PostShipmentDto>
    {
        public ShipmentValidation()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.OrderId).NotEmpty();
        }
    }
}
