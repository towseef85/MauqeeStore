using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.CatalogDtos.Brand;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class BrandRepository : IBrandRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BrandRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddBrand(PostBrandDto PostBrandDto, CancellationToken cancellationToken)
        {
            _context.Brands.Add(_mapper.Map<Brand>(PostBrandDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteBrand(Guid BrandId)
        {
            var position = await _context.Brands.FindAsync(BrandId);
            if (position == null) return false;
            position.Deleted = true;
            position.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetBrandDto>> GetAllBrand(Guid subscriptionId)
        {
            var result = await _context.Brands.Where(x => x.SubscriptionId == subscriptionId).ToListAsync();

            var resultData = _mapper.Map<List<GetBrandDto>>(result);
            return resultData;
        }

        public async Task<GetBrandDto> GetBrandById(Guid BrandId, Guid subscriptionId)
        {
            var result = await _context.Brands.Where(x => x.Id == BrandId && x.SubscriptionId == subscriptionId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetBrandDto>(result);
            return resultData;
        }

        public Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBrand(PostBrandDto PostBrandDto)
        {
            throw new NotImplementedException();
        }
    }
}
