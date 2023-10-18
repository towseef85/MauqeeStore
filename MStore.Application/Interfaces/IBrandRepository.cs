using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.BrandDto;

namespace MStore.Application.Interfaces
{
    public interface IBrandRepository
    {
        Task<ServiceStatus<List<GetBrandDto>>> GetAllBrand(Guid subscriptionId);
        Task<ServiceStatus<GetBrandDto>> GetBrandById(Guid BrandId);
        Task<ServiceStatus<List<GetBrandDto>>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
        Task<ServiceStatus<Unit>> AddBrand(PostBrandDto PostBrandDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateBrand(PostBrandDto PostBrandDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteBrand(Guid BrandId);
    }
}
