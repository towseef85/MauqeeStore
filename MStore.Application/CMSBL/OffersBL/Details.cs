using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CMSDtos.Offers;
using MStore.Application.Interfaces;

namespace MStore.Application.CMSBL.OffersBL
{
    public class Details
    {
        public class Query : IRequest<ServiceStatus<GetOffersDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetOffersDto>>
        {
            private readonly IOffersRepository _iOffersRepo;
            public Handler(IOffersRepository iOffersRepo)
            {
                _iOffersRepo = iOffersRepo;
            }

            public async Task<ServiceStatus<GetOffersDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iOffersRepo.GetOffersById(request.Id);
            }
        }
    }
}
