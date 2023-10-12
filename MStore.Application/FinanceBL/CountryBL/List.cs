using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CountryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CountryBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetCountryDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetCountryDto>>>
        {
            private readonly ICountryRepository _iCountryRepo;
            public Handler(ICountryRepository iCountryRepo)
            {
                _iCountryRepo = iCountryRepo;
            }
            public async Task<ServiceStatus<List<GetCountryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iCountryRepo.GetAllCountry(request.SubscriptionId);

            }
        }
    }
}
