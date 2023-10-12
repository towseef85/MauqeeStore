using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.WarehouseDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.WarehouseBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetWarehouseDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetWarehouseDto>>>
        {
            private readonly IWarehouseRepository _iWarehouseRepo;
            public Handler(IWarehouseRepository iWarehouseRepo)
            {
                _iWarehouseRepo = iWarehouseRepo;
            }
            public async Task<Result<List<GetWarehouseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iWarehouseRepo.GetAllWarehouse(request.SubscriptionId);
                return Result<List<GetWarehouseDto>>.Success(result);
            }
        }
    }
}
