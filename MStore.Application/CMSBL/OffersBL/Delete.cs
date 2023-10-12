using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.CMSBL.OffersBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IOffersRepository _iOffersRepo;
            public Handler(IOffersRepository iOffersRepo)
            {
                _iOffersRepo = iOffersRepo;
            }

            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                return await _iOffersRepo.DeleteOffers(request.Id);
               
            }
        }
    }
}
