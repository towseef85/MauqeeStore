using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderItemDto;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderItemBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostOrderItemDto OrderItem { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.OrderItem).SetValidator(new OrderItemValidation());
            }
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
                var result = await _iOrderItemRepo.AddOrderItem(request.OrderItem, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Order Item");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
