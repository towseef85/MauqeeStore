using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.WarehouseDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.WarehouseBL
{
    public class Details
    {
        public class Query  : IRequest<Result<GetWarehouseDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetWarehouseDto>>
        {
            private readonly IWarehouseRepository _iWarehouseRepo;
            public Handler(IWarehouseRepository iWarehouseRepo)
            {
                _iWarehouseRepo = iWarehouseRepo;
            }

            public async Task<Result<GetWarehouseDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iWarehouseRepo.GetWarehouseById(request.Id);
                 return Result<GetWarehouseDto>.Success(result);

            }
        }
    }
}

 