using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.PaymentStatusBL
{
    public class Edit
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
                return await _iPaymentStatusRepo.UpdatePaymentStatus(request.PaymentStatus, cancellationToken);

            }
        }
    }
}
