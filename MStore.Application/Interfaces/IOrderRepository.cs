
using System;
using MStore.Application.Dtos.SalesDto.OrderDto;

namespace MStore.Application.Interfaces
{
	public interface IOrderRepository
    { 
            Task<List<GetOrderDto>> GetAllOrder(Guid OrderId);
            Task<GetOrderDto> GetOrderById(Guid OrderId);
            //Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
            Task<bool> AddOrder(PostOrderDto PostOrderDto, CancellationToken cancellationToken);
            Task<bool> UpdateOrder(PostOrderDto PostOrderDto, CancellationToken cancellationToken);
            Task<bool> DeleteOrder(Guid OrderId);
        }
}


