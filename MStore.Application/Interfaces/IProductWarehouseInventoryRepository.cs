using MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto;

namespace MStore.Application.Interfaces
{
    public interface IProductWarehouseInventoryRepository
    {
        Task<List<GetProductWarehouseInventoryDto>> GetAllProductWarehouseInventory(Guid subscriptionId);
        Task<GetProductWarehouseInventoryDto> GetProductWarehouseInventoryById(Guid ProductWarehouseInventoryId);
        Task<List<GetProductWarehouseInventoryDto>> GetProductsForProductWarehouseInventory(Guid ProductWarehouseInventoryId, Guid subscriptionId);
        Task<bool> AddProductWarehouseInventory(PostProductWarehouseInventoryDto PostProductWarehouseInventoryDto, CancellationToken cancellationToken);
        Task<bool> UpdateProductWarehouseInventory(PostProductWarehouseInventoryDto PostProductWarehouseInventoryDto, CancellationToken cancellationToken);
        Task<bool> DeleteProductWarehouseInventory(Guid ProductWarehouseInventoryId);
    }
}
