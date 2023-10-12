using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.ShippingDto.ShipmentDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Shipping;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class ShipmentRepository : IShipmentRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ShipmentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddShipment(PostShipmentDto PostShipmentDto, CancellationToken cancellationToken)
        {
            _context.Shipments.Add(_mapper.Map<Shipment>(PostShipmentDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteShipment(Guid ShipmentId)
        {
            var data = await _context.Shipments.FindAsync(ShipmentId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetShipmentDto>> GetAllShipment(Guid subscriptionId)
        {
            var result = await _context.Shipments.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetShipmentDto>>(result);
            return resultData;
        }

        public async Task<GetShipmentDto> GetShipmentById(Guid ShipmentId)
        {
            var result = await _context.Shipments.Where(x => x.Id == ShipmentId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetShipmentDto>(result);
            return resultData;
        }

        public Task<List<GetShipmentDto>> GetProductsForShipment(Guid ShipmentId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateShipment(PostShipmentDto PostShipmentDto, CancellationToken cancellationToken)
        {
            var data = await _context.Shipments.FindAsync(PostShipmentDto.Id);
            if(data == null) return false;
            _mapper.Map(PostShipmentDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}
