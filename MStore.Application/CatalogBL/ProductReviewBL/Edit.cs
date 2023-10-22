using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductReviewDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductReviewBL
{
    public class Edit
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostProductReviewDto ProductReview { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductReview).SetValidator(new ProductReviewValidation());
            }
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
                var result = await _iProductReviewRepo.UpdateProductReview(request.ProductReview, cancellationToken);
                return result;
            }
        }
    }
}
