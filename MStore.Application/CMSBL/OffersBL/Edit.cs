using FluentValidation;
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
    public class Edit
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
                return await _iOffersRepo.UpdateOffers(request.Offers, cancellationToken);

            }
        }
    }
}
