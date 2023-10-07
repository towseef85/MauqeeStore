using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.PaymentStatusBL
{
    public class Create
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostPaymentStatusDto PaymentStatus { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.PaymentStatus).SetValidator(new PaymentStatusValidation());
            }
        }

        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IPaymentStatusRepository _iPaymentStatusRepo;
            public Handler(IPaymentStatusRepository iPaymentStatusRepo)
            {
                _iPaymentStatusRepo = iPaymentStatusRepo;
            }
            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iPaymentStatusRepo.AddPaymentStatus(request.PaymentStatus, cancellationToken);
                return result;
            }
        }
    }
}
