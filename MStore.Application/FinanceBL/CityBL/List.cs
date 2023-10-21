using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CityDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CityBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetCityDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetCityDto>>>
        {
            private readonly ICityRepository _iCityRepo;
            public Handler(ICityRepository iCityRepo)
            {
                _iCityRepo = iCityRepo;
            }
            public async Task<ServiceStatus<List<GetCityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iCityRepo.GetAllCity(request.SubscriptionId);

            }
        }
    }
}
