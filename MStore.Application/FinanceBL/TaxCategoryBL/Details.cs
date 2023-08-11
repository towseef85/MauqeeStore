using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.TaxCategory;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.TaxCategoryBL
{
    public class Details
    {
        public class Query : IRequest<Result<GetTaxCategoryDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetTaxCategoryDto>>
        {
            private readonly ITaxCategoryRepository _iTaxCategoryRepo;
            public Handler(ITaxCategoryRepository iTaxCategoryRepo)
            {
                _iTaxCategoryRepo = iTaxCategoryRepo;
            }

            public async Task<Result<GetTaxCategoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iTaxCategoryRepo.GetTaxCategoryById(request.Id);
                return Result<GetTaxCategoryDto>.Success(result);

            }
        }
    }
}
