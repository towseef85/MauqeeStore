using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SubscriptionDtos;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.IdentityBL.SubscriptionBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostSubscriptionDto Subscription { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Subscription).SetValidator(new SubscriptionValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ISubscriptionRepository _iSubscriptionRepo;
            public Handler(ISubscriptionRepository iSubscriptionRepo)
            {
                _iSubscriptionRepo = iSubscriptionRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iSubscriptionRepo.AddSubscription(request.Subscription, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Subscription");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
