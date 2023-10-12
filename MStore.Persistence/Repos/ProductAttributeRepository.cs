using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.CatalogDtos.BrandDto;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Persistence.Context;
using System.Threading;

namespace MStore.Persistence.Repos
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductAttributeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddProductAttribute(PostProductAttributeDto PostProductAttributeDto, CancellationToken cancellationToken)
        {
            _context.ProductAttributes.Add(_mapper.Map<ProductAttribute>(PostProductAttributeDto));
            var result = await _context.SaveChangesAsync(cancellationToken)>0;
            return result;
        }

        public async Task<bool> AddProductAttributeCombination(PostProductAttributeCombinationDto PostProductAttributeCombinationDto, CancellationToken cancellationToken)
        {
            _context.ProductAttributeCombinations.Add(_mapper.Map<ProductAttributeCombination>(PostProductAttributeCombinationDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public Task<bool> DeleteProductAttribute(Guid ProductAttributeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetProductAttributeDto>> GetAllProductAttribute(Guid subscriptionId)
        {
            

            var result = await _context.ProductAttributes.Include(x=>x.ProductAttributeValues).ToListAsync();

            return _mapper.Map<List<GetProductAttributeDto>>(result);
        }

        public async Task<GetProductAttributeDto> GetProductAttributeById(Guid ProductAttributeId)
        {
            var result = await _context.ProductAttributes.Include(x=>x.ProductAttributeValues).Where(x => x.Id == ProductAttributeId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetProductAttributeDto>(result);
            return resultData;
        }

        public Task<List<GetProductAttributeDto>> GetProductsForProductAttribute(Guid ProductAttributeId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductAttribute(PostProductAttributeDto PostProductAttributeDto, CancellationToken cancellationToken)
        {
            var data = await _context.ProductAttributes.FindAsync(PostProductAttributeDto.Id);
            if (data == null) return false;
            _context.ProductAttributes.Remove(data);
          var result1=  await _context.SaveChangesAsync(cancellationToken) >0;
            if (result1)
            {
                _context.ProductAttributes.Add(_mapper.Map<ProductAttribute>(PostProductAttributeDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                return result;
            }
            return false;
        }
    }
}
