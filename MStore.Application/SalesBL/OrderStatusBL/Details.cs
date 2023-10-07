using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderStatusDto;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderStatusBL
{
    public class Details
    {
        public class Query  : IRequest<Result<GetOrderStatusDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetOrderStatusDto>>
        {
            private readonly IOrderStatusRepository _iOrderStatusRepo;
            public Handler(IOrderStatusRepository iOrderStatusRepo)
            {
                _iOrderStatusRepo = iOrderStatusRepo;
            }

            public async Task<Result<GetOrderStatusDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iOrderStatusRepo.GetOrderStatusById(request.Id);
                 return Result<GetOrderStatusDto>.Success(result);

            }
        }
    }
}

 