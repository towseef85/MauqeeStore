using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class ProductWarehouseInventoryRepository : IProductWarehouseInventoryRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductWarehouseInventoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddProductWarehouseInventory(PostProductWarehouseInventoryDto PostProductWarehouseInventoryDto, CancellationToken cancellationToken)
        {
            _context.ProductWarehouseInventories.Add(_mapper.Map<ProductWarehouseInventory>(PostProductWarehouseInventoryDto));
            var result = await _context.SaveChangesAsync(cancellationToken)>0;
            return result;
        }


        public Task<bool> DeleteProductWarehouseInventory(Guid ProductWarehouseInventoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetProductWarehouseInventoryDto>> GetAllProductWarehouseInventory(Guid subscriptionId)
        {
            

            var result = await _context.ProductWarehouseInventories.Include(x=>x.StockQuantity).ToListAsync();

            return _mapper.Map<List<GetProductWarehouseInventoryDto>>(result);
        }

        public async Task<GetProductWarehouseInventoryDto> GetProductWarehouseInventoryById(Guid ProductWarehouseInventoryId)
        {
            var result = await _context.ProductWarehouseInventories.Include(x=>x.StockQuantity).Where(x => x.Id == ProductWarehouseInventoryId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetProductWarehouseInventoryDto>(result);
            return resultData;
        }

        public Task<List<GetProductWarehouseInventoryDto>> GetProductsForProductWarehouseInventory(Guid ProductWarehouseInventoryId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductWarehouseInventory(PostProductWarehouseInventoryDto PostProductWarehouseInventoryDto, CancellationToken cancellationToken)
        {
            var data = await _context.ProductWarehouseInventories.FindAsync(PostProductWarehouseInventoryDto.Id);
            if (data == null) return false;
            _context.ProductWarehouseInventories.Remove(data);
          var result1=  await _context.SaveChangesAsync(cancellationToken) >0;
            if (result1)
            {
                _context.ProductWarehouseInventories.Add(_mapper.Map<ProductWarehouseInventory>(PostProductWarehouseInventoryDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                return result;
            }
            return false;
        }

        
    }
}
