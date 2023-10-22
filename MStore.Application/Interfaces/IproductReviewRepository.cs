using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductReviewDto;

namespace MStore.Application.Interfaces
{
    public interface IProductReviewRepository
    {
        Task<ServiceStatus<List<GetProductReviewDto>>> GetAllProductReview(Guid subscriptionId);
        Task<ServiceStatus<GetProductReviewDto>> GetProductReviewById(Guid ProductReviewId);
        Task<ServiceStatus<List<GetProductReviewDto>>> GetProductsForProductReview(Guid ProductReviewId, Guid subscriptionId);
        Task<ServiceStatus<Unit>> AddProductReview(PostProductReviewDto PostProductReviewDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateProductReview(PostProductReviewDto PostProductReviewDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteProductReview(Guid ProductReviewId);
    }
}
