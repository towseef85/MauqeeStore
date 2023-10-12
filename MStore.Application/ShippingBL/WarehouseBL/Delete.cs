using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.WarehouseBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IWarehouseRepository _iWarehouseRepo;
            public Handler(IWarehouseRepository iWarehouseRepo)
            {
                _iWarehouseRepo = iWarehouseRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iWarehouseRepo.DeleteWarehouse(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to Delete Warehouse");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
