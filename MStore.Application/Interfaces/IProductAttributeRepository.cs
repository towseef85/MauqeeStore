using MStore.Application.Dtos.CatalogDtos.ProductAttribute;

namespace MStore.Application.Interfaces
{
    public interface IProductAttributeRepository
    {
        Task<List<GetProductAttributeDto>> GetAllProductAttribute(Guid subscriptionId);
        Task<GetProductAttributeDto> GetProductAttributeById(Guid ProductAttributeId, Guid subscriptionId);
        Task<List<GetProductAttributeDto>> GetProductsForProductAttribute(Guid ProductAttributeId, Guid subscriptionId);
        Task<bool> AddProductAttribute(PostProductAttributeDto PostProductAttributeDto, CancellationToken cancellationToken);
        Task<bool> AddProductAttributeCombination(PostProductAttributeCombinationDto PostProductAttributeCombinationDto, CancellationToken cancellationToken);
        Task<bool> UpdateProductAttribute(PostProductAttributeDto PostProductAttributeDto);
        Task<bool> DeleteProductAttribute(Guid ProductAttributeId);
    }
}
