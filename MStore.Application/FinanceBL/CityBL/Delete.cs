using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CityBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
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

                var result = await _iCityRepo.DeleteCity(request.Id);
                return result;
            }
        }
    }
}
