using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderDto;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderBL
{
    public class Details
    {
        public class Query  : IRequest<Result<GetOrderDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetOrderDto>>
        {
            private readonly IOrderRepository _iOrderRepo;
            public Handler(IOrderRepository iOrderRepo)
            {
                _iOrderRepo = iOrderRepo;
            }

            public async Task<Result<GetOrderDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iOrderRepo.GetOrderById(request.Id);
                 return Result<GetOrderDto>.Success(result);

            }
        }
    }
}

 