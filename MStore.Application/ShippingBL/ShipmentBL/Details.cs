using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.ShipmentDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.ShipmentBL
{
    public class Details
    {
        public class Query  : IRequest<Result<GetShipmentDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetShipmentDto>>
        {
            private readonly IShipmentRepository _iShipmentRepo;
            public Handler(IShipmentRepository iShipmentRepo)
            {
                _iShipmentRepo = iShipmentRepo;
            }

            public async Task<Result<GetShipmentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iShipmentRepo.GetShipmentById(request.Id);
                 return Result<GetShipmentDto>.Success(result);

            }
        }
    }
}

 