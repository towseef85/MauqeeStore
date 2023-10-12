using MStore.Application.Dtos.ShippingDto.WarehouseDto;

namespace MStore.Application.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<List<GetWarehouseDto>> GetAllWarehouse(Guid subscriptionId);
        Task<GetWarehouseDto> GetWarehouseById(Guid WarehouseId);
        Task<List<GetWarehouseDto>> GetProductsForWarehouse(Guid WarehouseId, Guid subscriptionId);
        Task<bool> AddWarehouse(PostWarehouseDto PostWarehouseDto, CancellationToken cancellationToken);
        Task<bool> UpdateWarehouse(PostWarehouseDto PostWarehouseDto, CancellationToken cancellationToken);
        Task<bool> DeleteWarehouse(Guid WarehouseId);
    }
}
