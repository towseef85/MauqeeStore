using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductReviewDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductReviewBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetProductReviewDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetProductReviewDto>>>
        {
            private readonly IProductReviewRepository _iProductReviewRepo;
            public Handler(IProductReviewRepository iProductReviewRepo)
            {
                _iProductReviewRepo = iProductReviewRepo;
            }
            public async Task<ServiceStatus<List<GetProductReviewDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductReviewRepo.GetAllProductReview(request.SubscriptionId);
                return result;
            }
        }
    }
}
