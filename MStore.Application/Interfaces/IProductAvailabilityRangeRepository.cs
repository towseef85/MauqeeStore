
using System;
using MStore.Application.Dtos.ShippingDto.ProductAvailabilityRangeDto;

namespace MStore.Application.Interfaces
{
	public interface IProductAvailabilityRangeRepository
    { 
            Task<List<GetProductAvailabilityRangeDto>> GetAllProductAvailabilityRange(Guid ProductAvailabilityRangeId);
            Task<GetProductAvailabilityRangeDto> GetProductAvailabilityRangeById(Guid ProductAvailabilityRangeId);
            //Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
            Task<bool> AddProductAvailabilityRange(PostProductAvailabilityRangeDto PostProductAvailabilityRangeDto, CancellationToken cancellationToken);
            Task<bool> UpdateProductAvailabilityRange(PostProductAvailabilityRangeDto PostProductAvailabilityRangeDto, CancellationToken cancellationToken);
            Task<bool> DeleteProductAvailabilityRange(Guid ProductAvailabilityRangeId);
        }
}


