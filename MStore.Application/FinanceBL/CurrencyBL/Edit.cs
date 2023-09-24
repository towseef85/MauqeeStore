using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CurrencyDto;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.CurrencyBL
{
    public class Edit
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostCurrencyDto Currency { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Currency).SetValidator(new CurrencyValidation());
            }
        }

        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly ICurrencyRepository _iCurrencyRepo;
            public Handler(ICurrencyRepository iCurrencyRepo)
            {
                _iCurrencyRepo = iCurrencyRepo;
            }
            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _iCurrencyRepo.UpdateCurrency(request.Currency, cancellationToken);

            }
        }
    }
}
