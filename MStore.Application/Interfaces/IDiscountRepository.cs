using System;
using MStore.Application.Dtos.MarketingDto.DiscountDto;

namespace MStore.Application.Interfaces
{
    public interface IDiscountRepository
        {
            Task<List<GetDiscountDto>> GetAllDiscount(Guid DiscountId);
            Task<GetDiscountDto> GetDiscountById(Guid DiscountId);
            //Task<List<GetDiscountDto>> GetProductsForDiscount(Guid DiscountId, Guid subscriptionId);
            Task<bool> AddDiscount(PostDiscountDto PostDiscountDto, CancellationToken cancellationToken);
            Task<bool> UpdateDiscount(PostDiscountDto PostDiscountDto, CancellationToken cancellationToken);
            Task<bool> DeleteDiscount(Guid DiscountId);
        }
    }


