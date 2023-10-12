using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.CategoryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.CategoryBL
{
    public class Details
    {
        public class Query : IRequest<Result<GetCategoriesDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetCategoriesDto>>
        {
            private readonly ICategoryRepository _iCategoryRepo;
            public Handler(ICategoryRepository iCategoryRepo)
            {
                _iCategoryRepo = iCategoryRepo;
            }

            public async Task<Result<GetCategoriesDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iCategoryRepo.GetCategoryById(request.Id);
                return Result<GetCategoriesDto>.Success(result);

            }
        }
    }
}
