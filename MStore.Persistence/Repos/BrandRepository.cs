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
            var data = await _context.Brands.FindAsync(BrandId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetBrandDto>> GetAllBrand(Guid subscriptionId)
        {
            var result = await _context.Brands.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetBrandDto>>(result);
            return resultData;
        }

        public async Task<GetBrandDto> GetBrandById(Guid BrandId)
        {
            var result = await _context.Brands.Where(x => x.Id == BrandId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetBrandDto>(result);
            return resultData;
        }

        public Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateBrand(PostBrandDto PostBrandDto, CancellationToken cancellationToken)
        {
            var data = await _context.Brands.FindAsync(PostBrandDto.Id);
            if(data == null) return false;
            _mapper.Map(PostBrandDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}
