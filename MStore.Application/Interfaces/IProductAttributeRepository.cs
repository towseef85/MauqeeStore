using MStore.Application.Dtos.CatalogDtos.ProductAttributeDto;

namespace MStore.Application.Interfaces
{
    public interface IProductAttributeRepository
    {
        Task<List<GetProductAttributeDto>> GetAllProductAttribute(Guid subscriptionId);
        Task<GetProductAttributeDto> GetProductAttributeById(Guid ProductAttributeId);
        Task<List<GetProductAttributeDto>> GetProductsForProductAttribute(Guid ProductAttributeId, Guid subscriptionId);
        Task<bool> AddProductAttribute(PostProductAttributeDto PostProductAttributeDto, CancellationToken cancellationToken);
        Task<bool> AddProductAttributeCombination(PostProductAttributeCombinationDto PostProductAttributeCombinationDto, CancellationToken cancellationToken);
        Task<bool> UpdateProductAttribute(PostProductAttributeDto PostProductAttributeDto, CancellationToken cancellationToken);
        Task<bool> DeleteProductAttribute(Guid ProductAttributeId);
    }
}
