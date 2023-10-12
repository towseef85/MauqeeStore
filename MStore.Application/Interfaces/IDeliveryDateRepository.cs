
using System;
using MStore.Application.Dtos.ShippingDto.DeliveryDateDto;

namespace MStore.Application.Interfaces
{
	public interface IDeliveryDateRepository
    { 
            Task<List<GetDeliveryDateDto>> GetAllDeliveryDate(Guid DeliveryDateId);
            Task<GetDeliveryDateDto> GetDeliveryDateById(Guid DeliveryDateId);
            //Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
            Task<bool> AddDeliveryDate(PostDeliveryDateDto PostDeliveryDateDto, CancellationToken cancellationToken);
            Task<bool> UpdateDeliveryDate(PostDeliveryDateDto PostDeliveryDateDto, CancellationToken cancellationToken);
            Task<bool> DeleteDeliveryDate(Guid DeliveryDateId);
        }
}


