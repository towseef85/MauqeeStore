using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IOrderRepository _iOrderRepo;
            public Handler(IOrderRepository iOrderRepo)
            {
                _iOrderRepo = iOrderRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iOrderRepo.DeleteOrder(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to Delete Order");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
