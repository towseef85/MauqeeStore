using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderDto;
using MStore.Application.Interfaces;

namespace MStore.Application.SalesBL.OrderBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostOrderDto Order { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Order).SetValidator(new OrderValidation());
            }
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
                var result = await _iOrderRepo.AddOrder(request.Order, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Order");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
