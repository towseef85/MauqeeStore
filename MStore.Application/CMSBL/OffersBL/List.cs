using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CMSDtos.Offers;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CMSBL.OffersBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetOffersDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetOffersDto>>>
        {
            private readonly IOffersRepository _iOffersRepo;
            public Handler(IOffersRepository iOffersRepo)
            {
                _iOffersRepo = iOffersRepo;
            }
            public async Task<ServiceStatus<List<GetOffersDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iOffersRepo.GetAllOffers(request.SubscriptionId);
                
            }
        }
    }
}
