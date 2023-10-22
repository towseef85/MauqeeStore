using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductReviewDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductReviewBL
{
    public class Details
    {
        public class Query  : IRequest<ServiceStatus<GetProductReviewDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetProductReviewDto>>
        {
            private readonly IProductReviewRepository _iProductReviewRepo;
            public Handler(IProductReviewRepository iProductReviewRepo)
            {
                _iProductReviewRepo = iProductReviewRepo;
            }

            public async Task<ServiceStatus<GetProductReviewDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductReviewRepo.GetProductReviewById(request.Id);
                return result;

            }
        }
    }
}
