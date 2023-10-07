using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.FinanceDto.TaxCategoryDto;
using MStore.Application.Interfaces;
using MStore.Domain.Financials;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class TaxCategoryRepository : ITaxCategoryRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TaxCategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddTaxCategory(PostTaxCategoryDto PostTaxCategoryDto, CancellationToken cancellationToken)
        {
            _context.TaxCategories.Add(_mapper.Map<TaxCategory>(PostTaxCategoryDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteTaxCategory(Guid TaxCategoryId)
        {
            var data = await _context.TaxCategories.FindAsync(TaxCategoryId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetTaxCategoryDto>> GetAllTaxCategory(Guid subscriptionId)
        {

            var result = await _context.TaxCategories.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetTaxCategoryDto>>(result);
            return resultData;
        }

        public async Task<GetTaxCategoryDto> GetTaxCategoryById(Guid TaxCategoryId)
        {
            var result = await _context.TaxCategories.Where(x => x.Id == TaxCategoryId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetTaxCategoryDto>(result);
            return resultData;
        }

        public async Task<bool> UpdateTaxCategory(PostTaxCategoryDto PostTaxCategoryDto, CancellationToken cancellationToken)
        {
            var data = await _context.TaxCategories.FindAsync(PostTaxCategoryDto.Id);
            if (data == null) return false;
           
            _mapper.Map(PostTaxCategoryDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
           
            return result;
        }
    }
}
