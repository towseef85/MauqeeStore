using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.ShipmentBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IShipmentRepository _iShipmentRepo;
            public Handler(IShipmentRepository iShipmentRepo)
            {
                _iShipmentRepo = iShipmentRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iShipmentRepo.DeleteShipment(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to Delete Shipment");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
