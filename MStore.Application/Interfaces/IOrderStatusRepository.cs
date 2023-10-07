
using System;
using MStore.Application.Dtos.SalesDto.OrderStatusDto;

namespace MStore.Application.Interfaces
{
	public interface IOrderStatusRepository
    { 
            Task<List<GetOrderStatusDto>> GetAllOrderStatus(Guid OrderStatusId);
            Task<GetOrderStatusDto> GetOrderStatusById(Guid OrderStatusId);
            //Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
            Task<bool> AddOrderStatus(PostOrderStatusDto PostOrderStatusDto, CancellationToken cancellationToken);
            Task<bool> UpdateOrderStatus(PostOrderStatusDto PostOrderStatusDto, CancellationToken cancellationToken);
            Task<bool> DeleteOrderStatus(Guid OrderStatusId);
        }
}


