using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.AffiliateBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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

                var result = await _iAffiliateRepo.DeleteAffiliate(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to update Position");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
