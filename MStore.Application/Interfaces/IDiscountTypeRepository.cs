using System;
using MStore.Application.Dtos.MarketingDto.DiscountTypeDto;

namespace MStore.Application.Interfaces
{
    public interface IDiscountTypeRepository
        {
            Task<List<GetDiscountTypeDto>> GetAllDiscountType(Guid DiscountTypeId);
            Task<GetDiscountTypeDto> GetDiscountTypeById(Guid DiscountTypeId);
            //Task<List<GetDiscountTypeDto>> GetProductsForDiscountType(Guid DiscountTypeId, Guid subscriptionId);
            Task<bool> AddDiscountType(PostDiscountTypeDto PostDiscountTypeDto, CancellationToken cancellationToken);
            Task<bool> UpdateDiscountType(PostDiscountTypeDto PostDiscountTypeDto, CancellationToken cancellationToken);
            Task<bool> DeleteDiscountType(Guid DiscountTypeId);
        }
    }


