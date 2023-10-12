using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.DeliveryDateDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.DeliveryDateBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostDeliveryDateDto DeliveryDate { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DeliveryDate).SetValidator(new DeliveryDateValidation());
            }
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
                var result = await _iDeliveryDateRepo.AddDeliveryDate(request.DeliveryDate, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add DeliveryDate");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
