using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CountryBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
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

                var result = await _iCountryRepo.DeleteCountry(request.Id);
                return result;
            }
        }
    }
}
