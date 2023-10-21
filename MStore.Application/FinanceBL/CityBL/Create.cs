using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CityDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CityBL
{
    public class Create
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostCityDto City { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.City).SetValidator(new CityValidation());
            }
        }

        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly ICityRepository _iCityRepo;
            public Handler(ICityRepository iCityRepo)
            {
                _iCityRepo = iCityRepo;
            }
            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iCityRepo.AddCity(request.City, cancellationToken);
                return result;
            }
        }
    }
}
