using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.DeliveryDateBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IDeliveryDateRepository _iDeliveryDateRepo;
            public Handler(IDeliveryDateRepository iDeliveryDateRepo)
            {
                _iDeliveryDateRepo = iDeliveryDateRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iDeliveryDateRepo.DeleteDeliveryDate(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to Delete Delivery Date");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
