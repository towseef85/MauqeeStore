using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderItemDto;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderItemBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetOrderItemDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetOrderItemDto>>>
        {
            private readonly IOrderItemRepository _iOrderItemRepo;
            public Handler(IOrderItemRepository iOrderItemRepo)
            {
                _iOrderItemRepo = iOrderItemRepo;
            }
            public async Task<Result<List<GetOrderItemDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iOrderItemRepo.GetAllOrderItem(request.SubscriptionId);
                return Result<List<GetOrderItemDto>>.Success(result);
            }
        }
    }
}
