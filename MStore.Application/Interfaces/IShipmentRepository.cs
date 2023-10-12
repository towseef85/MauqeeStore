using MStore.Application.Dtos.ShippingDto.ShipmentDto;

namespace MStore.Application.Interfaces
{
    public interface IShipmentRepository
    {
        Task<List<GetShipmentDto>> GetAllShipment(Guid subscriptionId);
        Task<GetShipmentDto> GetShipmentById(Guid ShipmentId);
        Task<List<GetShipmentDto>> GetProductsForShipment(Guid ShipmentId, Guid subscriptionId);
        Task<bool> AddShipment(PostShipmentDto PostShipmentDto, CancellationToken cancellationToken);
        Task<bool> UpdateShipment(PostShipmentDto PostShipmentDto, CancellationToken cancellationToken);
        Task<bool> DeleteShipment(Guid ShipmentId);
    }
}
