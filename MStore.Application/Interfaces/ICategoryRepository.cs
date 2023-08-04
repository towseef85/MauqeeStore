using MStore.Application.Dtos.CatalogDtos.Category;

namespace MStore.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<GetCategoriesDto>> GetAllCategory(Guid subscriptionId);
        Task<GetCategoriesDto> GetCategoryById(Guid CategoryId, Guid subscriptionId);
        Task<List<GetCategoriesDto>> GetProductsForCategory(Guid CategoryId, Guid subscriptionId);
        Task<bool> AddCategory(PostCategoryDto PostCategoryDto, CancellationToken cancellationToken);
        Task<bool> UpdateCategory(PostCategoryDto PostCategoryDto);
        Task<bool> DeleteCategory(Guid CategoryId);
    }
}
