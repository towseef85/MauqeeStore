using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.ProductReviewDto;

namespace MStore.Application.CatalogBL.ProductReviewBL
{
    public class ProductReviewValidation : AbstractValidator<PostProductReviewDto>
    {
        public ProductReviewValidation()
        {
            RuleFor(x => x.ReviewDesc).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}
