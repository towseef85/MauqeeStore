
using System;
using MStore.Application.Dtos.SalesDto.OrderItemDto;

namespace MStore.Application.Interfaces
{
	public interface IOrderItemRepository
    { 
            Task<List<GetOrderItemDto>> GetAllOrderItem(Guid OrderItemId);
            Task<GetOrderItemDto> GetOrderItemById(Guid OrderItemId);
            //Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
            Task<bool> AddOrderItem(PostOrderItemDto PostOrderItemDto, CancellationToken cancellationToken);
            Task<bool> UpdateOrderItem(PostOrderItemDto PostOrderItemDto, CancellationToken cancellationToken);
            Task<bool> DeleteOrderItem(Guid OrderItemId);
        }
}


