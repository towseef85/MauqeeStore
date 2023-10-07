using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.TaxCategoryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.TaxCategoryBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetTaxCategoryDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetTaxCategoryDto>>>
        {
            private readonly ITaxCategoryRepository _iTaxCategoryRepo;
            public Handler(ITaxCategoryRepository iTaxCategoryRepo)
            {
                _iTaxCategoryRepo = iTaxCategoryRepo;
            }
            public async Task<Result<List<GetTaxCategoryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iTaxCategoryRepo.GetAllTaxCategory(request.SubscriptionId);
                return Result<List<GetTaxCategoryDto>>.Success(result);
            }
        }
    }
}
