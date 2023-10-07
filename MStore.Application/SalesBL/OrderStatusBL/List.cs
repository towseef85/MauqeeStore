using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderStatusDto;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderStatusBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetOrderStatusDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetOrderStatusDto>>>
        {
            private readonly IOrderStatusRepository _iOrderStatusRepo;
            public Handler(IOrderStatusRepository iOrderStatusRepo)
            {
                _iOrderStatusRepo = iOrderStatusRepo;
            }
            public async Task<Result<List<GetOrderStatusDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iOrderStatusRepo.GetAllOrderStatus(request.SubscriptionId);
                return Result<List<GetOrderStatusDto>>.Success(result);
            }
        }
    }
}
