using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderStatusBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IOrderStatusRepository _iOrderStatusRepo;
            public Handler(IOrderStatusRepository iOrderStatusRepo)
            {
                _iOrderStatusRepo = iOrderStatusRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iOrderStatusRepo.DeleteOrderStatus(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to Delete Order Status");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
