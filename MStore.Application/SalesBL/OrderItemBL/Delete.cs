using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderItemBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IOrderItemRepository _iOrderItemRepo;
            public Handler(IOrderItemRepository iOrderItemRepo)
            {
                _iOrderItemRepo = iOrderItemRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iOrderItemRepo.DeleteOrderItem(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to Delete Order Item");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
