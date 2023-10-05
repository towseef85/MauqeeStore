using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.MarketingDto.DiscountDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Marketing.Discounts;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class DiscountRepository : IDiscountRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DiscountRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddDiscount(PostDiscountDto PostDiscountDto, CancellationToken cancellationToken)
        {
            _context.Discounts.Add(_mapper.Map<Discount>(PostDiscountDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteDiscount(Guid DiscountId)
        {
            var data = await _context.Discounts.FindAsync(DiscountId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetDiscountDto>> GetAllDiscount(Guid subscriptionId)
        {
            var result = await _context.Discounts.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetDiscountDto>>(result);
            return resultData;
        }

        public async Task<GetDiscountDto> GetDiscountById(Guid DiscountId)
        {
            var result = await _context.Discounts.Where(x => x.Id == DiscountId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetDiscountDto>(result);
            return resultData;
        }

        public Task<List<GetDiscountDto>> GetProductsForDiscount(Guid DiscountId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDiscount(PostDiscountDto PostDiscountDto, CancellationToken cancellationToken)
        {
            var data = await _context.Discounts.FindAsync(PostDiscountDto.Id);
            if(data == null) return false;
            _mapper.Map(PostDiscountDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}
