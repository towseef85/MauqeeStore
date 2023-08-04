using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.CatalogDtos.Category;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddCategory(PostCategoryDto PostCategoryDto, CancellationToken cancellationToken)
        {
            _context.Categories.Add(_mapper.Map<Category>(PostCategoryDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public Task<bool> DeleteCategory(Guid CategoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetCategoriesDto>> GetAllCategory(Guid subscriptionId)
        {
            var result = await _context.Categories.Where(x=>x.SubscriptionId == subscriptionId).ToListAsync();

            var resultData = _mapper.Map<List<GetCategoriesDto>>(result);
            return resultData;
        }

        public async Task<GetCategoriesDto> GetCategoryById(Guid CategoryId, Guid subscriptionId)
        {
            var result = await _context.Categories.Where(x=>x.Id == CategoryId && x.SubscriptionId == subscriptionId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetCategoriesDto>(result);
            return resultData;
        }

        public Task<List<GetCategoriesDto>> GetProductsForCategory(Guid CategoryId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategory(PostCategoryDto PostCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
