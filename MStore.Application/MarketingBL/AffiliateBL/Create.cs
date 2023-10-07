using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.AffiliateDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.AffiliateBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostAffiliateDto Affiliate { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Affiliate).SetValidator(new AffiliateValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IAffiliateRepository _iAffiliateRepo;
            public Handler(IAffiliateRepository iAffiliateRepo)
            {
                _iAffiliateRepo = iAffiliateRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iAffiliateRepo.AddAffiliate(request.Affiliate, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Affiliate");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
