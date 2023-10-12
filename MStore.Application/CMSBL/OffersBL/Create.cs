using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CMSDtos.Offers;
using MStore.Application.Interfaces;

namespace MStore.Application.CMSBL.OffersBL
{
    public class Create
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostOffersDto Offers { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Offers).SetValidator(new OffersValidation());
            }
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
                var result = await _iOffersRepo.AddOffers(request.Offers, cancellationToken);
                return result;
            }
        }
    }
}
