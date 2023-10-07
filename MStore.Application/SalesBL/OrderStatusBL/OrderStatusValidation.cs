using FluentValidation;
using MStore.Application.Dtos.SalesDto.OrderStatusDto;

namespace MStore.Application.SalesBL.OrderStatusBL

{
    public class OrderStatusValidation : AbstractValidator<PostOrderStatusDto>
    {
        public OrderStatusValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}
