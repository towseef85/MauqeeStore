using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.AffiliateDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.AffiliateBL
{
    public class Details
    {
        public class Query  : IRequest<Result<GetAffiliateDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetAffiliateDto>>
        {
            private readonly IAffiliateRepository _iAffiliateRepo;
            public Handler(IAffiliateRepository iAffiliateRepo)
            {
                _iAffiliateRepo = iAffiliateRepo;
            }

            public async Task<Result<GetAffiliateDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iAffiliateRepo.GetAffiliateById(request.Id);
                 return Result<GetAffiliateDto>.Success(result);

            }
        }
    }
}
