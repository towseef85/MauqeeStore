using MStore.Application.Dtos.CatalogDtos.Brand;

namespace MStore.Application.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<GetBrandDto>> GetAllBrand(Guid subscriptionId);
        Task<GetBrandDto> GetBrandById(Guid BrandId, Guid subscriptionId);
        Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
        Task<bool> AddBrand(PostBrandDto PostBrandDto, CancellationToken cancellationToken);
        Task<bool> UpdateBrand(PostBrandDto PostBrandDto);
        Task<bool> DeleteBrand(Guid BrandId);
    }
}
