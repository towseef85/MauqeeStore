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

        public async Task<bool> DeleteCategory(Guid CategoryId)
        {
            var data = await _context.Categories.FindAsync(CategoryId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetCategoriesDto>> GetAllCategory(Guid subscriptionId)
        {
            var result = await _context.Categories.Where(x=>x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetCategoriesDto>>(result);
            return resultData;
        }

        public async Task<GetCategoriesDto> GetCategoryById(Guid CategoryId)
        {
            var result = await _context.Categories.Where(x=>x.Id == CategoryId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetCategoriesDto>(result);
            return resultData;
        }

        public Task<List<GetCategoriesDto>> GetProductsForCategory(Guid CategoryId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCategory(PostCategoryDto PostCategoryDto, CancellationToken cancellationToken)
        {
            var data = await _context.Categories.FindAsync(PostCategoryDto.Id);
            if (data == null) return false;
            _mapper.Map(PostCategoryDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}
