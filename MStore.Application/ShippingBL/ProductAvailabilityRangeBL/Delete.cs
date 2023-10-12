using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.ProductAvailabilityRangeBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IProductAvailabilityRangeRepository _iProductAvailabilityRangeRepo;
            public Handler(IProductAvailabilityRangeRepository iProductAvailabilityRangeRepo)
            {
                _iProductAvailabilityRangeRepo = iProductAvailabilityRangeRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iProductAvailabilityRangeRepo.DeleteProductAvailabilityRange(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to Delete Product Availability Range");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
