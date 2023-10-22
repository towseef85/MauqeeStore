using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductReviewBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IProductReviewRepository _iProductReviewRepo;
            public Handler(IProductReviewRepository iProductReviewRepo)
            {
                _iProductReviewRepo = iProductReviewRepo;
            }

            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iProductReviewRepo.DeleteProductReview(request.Id);
                return result;
               
            }
        }
    }
}
