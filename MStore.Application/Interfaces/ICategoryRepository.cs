using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
