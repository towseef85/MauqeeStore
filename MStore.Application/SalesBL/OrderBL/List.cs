using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderDto;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetOrderDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetOrderDto>>>
        {
            private readonly IOrderRepository _iOrderRepo;
            public Handler(IOrderRepository iOrderRepo)
            {
                _iOrderRepo = iOrderRepo;
            }
            public async Task<Result<List<GetOrderDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iOrderRepo.GetAllOrder(request.SubscriptionId);
                return Result<List<GetOrderDto>>.Success(result);
            }
        }
    }
}
