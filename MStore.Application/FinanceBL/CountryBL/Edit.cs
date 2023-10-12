using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CountryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CountryBL
{
    public class Edit
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostCountryDto Country { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Country).SetValidator(new CountryValidation());
            }
        }

        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly ICountryRepository _iCountryRepo;
            public Handler(ICountryRepository iCountryRepo)
            {
                _iCountryRepo = iCountryRepo;
            }
            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _iCountryRepo.UpdateCountry(request.Country, cancellationToken);

            }
        }
    }
}
