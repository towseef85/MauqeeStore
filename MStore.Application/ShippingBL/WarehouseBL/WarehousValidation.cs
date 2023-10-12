using FluentValidation;
using MStore.Application.Dtos.ShippingDto.WarehouseDto;
namespace MStore.Application.ShippingBL.WarehouseBL
{
    public class WarehouseValidation : AbstractValidator<PostWarehouseDto>
    {
        public WarehouseValidation()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.AddressId).NotEmpty();
        }
    }
}
