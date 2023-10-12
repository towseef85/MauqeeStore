using FluentValidation;
using MStore.Application.Dtos.SalesDto.OrderItemDto;

namespace MStore.Application.SalesBL.OrderItemBL

{
    public class OrderItemValidation : AbstractValidator<PostOrderItemDto>
    {
        public OrderItemValidation()
        {
            //RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.OrderItemId).NotEmpty();
        }
    }
}
