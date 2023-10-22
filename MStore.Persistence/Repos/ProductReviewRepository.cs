using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductReviewDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductReviewRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddProductReview(PostProductReviewDto PostProductReviewDto, CancellationToken cancellationToken)
        {
            try
            {
                var hasName = await _context.ProductReviews.Where(x=>x.ReviewDesc == PostProductReviewDto.ReviewDesc).AnyAsync();
                if (hasName)
                {
                    return new ServiceStatus<Unit>
                    {
                        Code = System.Net.HttpStatusCode.Conflict,
                        Message = "ProductReview Name Already Exists",
                        Object = Unit.Value
                    };
                }
                
                _context.ProductReviews.Add(_mapper.Map<ProductReview>(PostProductReviewDto));
                 await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "ProductReview Added Successfully!",
                    Object = Unit.Value,

                };
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message.ToString(),
                    InnerMessage = exception.InnerException?.Message != null ? exception.InnerException.Message : null,
                    Object = Unit.Value,
                };
            }
        
           
        }

        public async Task<ServiceStatus<Unit>> DeleteProductReview(Guid ProductReviewId)
        {
            try
            {
                var data = await _context.ProductReviews.FindAsync(ProductReviewId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "ProductReview Deleted Successfully",
                    Object = Unit.Value,
                };
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = $"Unable to Delete Error= ${ex.Message.ToString()}",
                    InnerMessage = exception.InnerException?.Message != null ? exception.InnerException.Message : null,
                    Object = Unit.Value,
                };
            }
          
        }

        public async Task<ServiceStatus<List<GetProductReviewDto>>> GetAllProductReview(Guid subscriptionId)
        {
            var result = await _context.ProductReviews.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetProductReviewDto>>(result);
            return new ServiceStatus<List<GetProductReviewDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Offers Fetch Successfully",
                Object = resultData
            };
           
        }

        public async Task<ServiceStatus<GetProductReviewDto>> GetProductReviewById(Guid ProductReviewId)
        {
            try
            {
                var result = await _context.ProductReviews.Where(x => x.Id == ProductReviewId).FirstOrDefaultAsync();
                return new ServiceStatus<GetProductReviewDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Offer with Id ${ProductReviewId} fetch successfully",
                    Object = _mapper.Map<GetProductReviewDto>(result)
                };
            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetProductReviewDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
          

        }

        public Task<ServiceStatus<List<GetProductReviewDto>>> GetProductsForProductReview(Guid ProductReviewId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceStatus<Unit>> UpdateProductReview(PostProductReviewDto PostProductReviewDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.ProductReviews.FindAsync(PostProductReviewDto.Id);
                _mapper.Map(PostProductReviewDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"ProductReview updated Successfully",
                    Object = Unit.Value
                };
            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = Unit.Value
                };
            }
           
        
        }
    }
}
