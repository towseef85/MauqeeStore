using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.Category;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
