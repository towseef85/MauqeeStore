using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CountryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CountryBL
{
    public class Details
    {
        public class Query : IRequest<ServiceStatus<GetCountryDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetCountryDto>>
        {
            private readonly ICountryRepository _iCountryRepo;
            public Handler(ICountryRepository iCountryRepo)
            {
                _iCountryRepo = iCountryRepo;
            }

            public async Task<ServiceStatus<GetCountryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iCountryRepo.GetCountryById(request.Id);
            }
        }
    }
}
