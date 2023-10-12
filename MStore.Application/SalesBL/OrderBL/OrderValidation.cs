using FluentValidation;
using MStore.Application.Dtos.SalesDto.OrderDto;
namespace MStore.Application.SalesBL.OrderBL
{
    public class OrderValidation : AbstractValidator<PostOrderDto>
    {
        public OrderValidation()
        {
            //RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
            //RuleFor(x => x.or).NotEmpty();
        }
    }
}
