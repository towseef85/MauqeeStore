using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.CatalogDtos.BrandDto;
using MStore.Application.Dtos.CatalogDtos.ProductDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Persistence.Repos
{
    public class ProductRepository : IProductRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddProduct(PostProductDto PostProductDto, CancellationToken cancellationToken)
        {

            _context.Products.Add(_mapper.Map<Product>(PostProductDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public Task<bool> DeleteProduct(Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetProductDto>> GetAllProduct(Guid subscriptionId)
        {
            var result = await _context.Products.Include(x=>x.ProductAttributeCombinations).ThenInclude(x=>x.ProductAttributes).ThenInclude(x=>x.ProductAttributeValues).Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetProductDto>>(result);
            return resultData;
        }

        public Task<GetProductDto> GetProductById(Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(PostProductDto PostProductDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
