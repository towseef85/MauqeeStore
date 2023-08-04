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
