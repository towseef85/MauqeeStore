using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.ShipmentDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.ShipmentBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostShipmentDto Shipment { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Shipment).SetValidator(new ShipmentValidation());
            }
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
                var result = await _iShipmentRepo.AddShipment(request.Shipment, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Shipment");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
