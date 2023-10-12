using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderItemDto;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderItemBL
{
    public class Details
    {
        public class Query  : IRequest<Result<GetOrderItemDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetOrderItemDto>>
        {
            private readonly IOrderItemRepository _iOrderItemRepo;
            public Handler(IOrderItemRepository iOrderItemRepo)
            {
                _iOrderItemRepo = iOrderItemRepo;
            }

            public async Task<Result<GetOrderItemDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iOrderItemRepo.GetOrderItemById(request.Id);
                 return Result<GetOrderItemDto>.Success(result);

            }
        }
    }
}

 