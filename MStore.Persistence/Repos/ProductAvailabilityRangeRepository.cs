using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.ShippingDto.ProductAvailabilityRangeDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Shipping;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class ProductAvailabilityRangeRepository : IProductAvailabilityRangeRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductAvailabilityRangeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddProductAvailabilityRange(PostProductAvailabilityRangeDto PostProductAvailabilityRangeDto, CancellationToken cancellationToken)
        {
            _context.ProductAvailabilityRanges.Add(_mapper.Map<ProductAvailabilityRange>(PostProductAvailabilityRangeDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }


        public async Task<bool> DeleteProductAvailabilityRange(Guid ProductAvailabilityRangeId)
        {
            var data = await _context.ProductAvailabilityRanges.FindAsync(ProductAvailabilityRangeId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetProductAvailabilityRangeDto>> GetAllProductAvailabilityRange(Guid subscriptionId)
        {
            var result = await _context.ProductAvailabilityRanges.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetProductAvailabilityRangeDto>>(result);
            return resultData;
        }

        public async Task<GetProductAvailabilityRangeDto> GetProductAvailabilityRangeById(Guid ProductAvailabilityRangeId)
        {
            var result = await _context.ProductAvailabilityRanges.Where(x => x.Id == ProductAvailabilityRangeId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetProductAvailabilityRangeDto>(result);
            return resultData;
        }


        public Task<List<GetProductAvailabilityRangeDto>> GetProductsForProductAvailabilityRange(Guid ProductAvailabilityRangeId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductAvailabilityRange(PostProductAvailabilityRangeDto PostProductAvailabilityRangeDto, CancellationToken cancellationToken)
        {
            var data = await _context.ProductAvailabilityRanges.FindAsync(PostProductAvailabilityRangeDto.Id);
            if(data == null) return false;
            _mapper.Map(PostProductAvailabilityRangeDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

    }
}
