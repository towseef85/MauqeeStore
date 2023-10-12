using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.CategoryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.CategoryBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetCategoriesDto>>> 
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetCategoriesDto>>>
        {
            private readonly ICategoryRepository _iCategoryRepo;
            public Handler(ICategoryRepository iCategoryRepo)
            {
                _iCategoryRepo = iCategoryRepo;
            }
            public async Task<Result<List<GetCategoriesDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iCategoryRepo.GetAllCategory(request.SubscriptionId);
                return Result<List<GetCategoriesDto>>.Success(result);
            }
        }
    }
}
