using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CityDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CityBL
{
    public class Details
    {
        public class Query : IRequest<ServiceStatus<GetCityDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetCityDto>>
        {
            private readonly ICityRepository _iCityRepo;
            public Handler(ICityRepository iCityRepo)
            {
                _iCityRepo = iCityRepo;
            }

            public async Task<ServiceStatus<GetCityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iCityRepo.GetCityById(request.Id);
            }
        }
    }
}
