using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SalesDto.OrderStatusDto;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.SalesBL.OrderStatusBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostOrderStatusDto OrderStatus { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.OrderStatus).SetValidator(new OrderStatusValidation());
            }
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
                var result = await _iOrderStatusRepo.UpdateOrderStatus(request.OrderStatus, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Order Status");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
