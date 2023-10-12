using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.ShippingDto.WarehouseDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Shipping;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class WarehouseRepository : IWarehouseRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public WarehouseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddWarehouse(PostWarehouseDto PostWarehouseDto, CancellationToken cancellationToken)
        {
            _context.Warehouses.Add(_mapper.Map<Warehouse>(PostWarehouseDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteWarehouse(Guid WarehouseId)
        {
            var data = await _context.Warehouses.FindAsync(WarehouseId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetWarehouseDto>> GetAllWarehouse(Guid subscriptionId)
        {
            var result = await _context.Warehouses.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetWarehouseDto>>(result);
            return resultData;
        }

        public async Task<GetWarehouseDto> GetWarehouseById(Guid WarehouseId)
        {
            var result = await _context.Warehouses.Where(x => x.Id == WarehouseId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetWarehouseDto>(result);
            return resultData;
        }

        public Task<List<GetWarehouseDto>> GetProductsForWarehouse(Guid WarehouseId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateWarehouse(PostWarehouseDto PostWarehouseDto, CancellationToken cancellationToken)
        {
            var data = await _context.Warehouses.FindAsync(PostWarehouseDto.Id);
            if(data == null) return false;
            _mapper.Map(PostWarehouseDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}
