using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.ShipmentDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.ShipmentBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetShipmentDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetShipmentDto>>>
        {
            private readonly IShipmentRepository _iShipmentRepo;
            public Handler(IShipmentRepository iShipmentRepo)
            {
                _iShipmentRepo = iShipmentRepo;
            }
            public async Task<Result<List<GetShipmentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iShipmentRepo.GetAllShipment(request.SubscriptionId);
                return Result<List<GetShipmentDto>>.Success(result);
            }
        }
    }
}
