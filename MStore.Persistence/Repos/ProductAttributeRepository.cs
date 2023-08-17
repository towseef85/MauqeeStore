using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.CatalogDtos.ProductAttribute;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Persistence.Context;

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

        public Task<GetProductAttributeDto> GetProductAttributeById(Guid ProductAttributeId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetProductAttributeDto>> GetProductsForProductAttribute(Guid ProductAttributeId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAttribute(PostProductAttributeDto PostProductAttributeDto)
        {
            throw new NotImplementedException();
        }
    }
}
